using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace XBox
{
    public sealed class StandardBootstrapper : BootstrapperBase
    {
        //private static readonly LoggerProxy Log = new LoggerProxy();

        private readonly List<Assembly> _appAssemblies = new List<Assembly>();
        private CompositionContainer _container;
        private Exception _startupException;

        public StandardBootstrapper()
        {
            Dispatcher.CurrentDispatcher.ShutdownStarted += DispatcherShutdownStarted;

            var entryAssembly = Assembly.GetEntryAssembly();
            var entryName = entryAssembly.GetAssemblyName();
            var entryDir = Path.GetDirectoryName(entryAssembly.Location);

            _appAssemblies.Add(entryAssembly);

            Initialize();
        }

        protected override void Configure()
        {
            var catalogs = _appAssemblies.Select(a => new AssemblyCatalog(a)).ToList();
            var catalog = new AggregateCatalog(catalogs);
            _container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);

            //var basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var windowManager = new WindowManager();
            //var fileServices = new FileServices(basePath);
            //var vmFactory = new ViewModelFactory(_container, _appAssemblies);

            var batch = new CompositionBatch();
            //batch.AddExportedValue<IFileServices>(fileServices);
            batch.AddExportedValue<IWindowManager>(windowManager);
            //batch.AddExportedValue<IViewModelFactory>(vmFactory);

            try
            {
                _container.Compose(batch);
            }
            catch (CompositionException ex)
            {
                var rootCause = ex.RootCauses.LastOrDefault() ?? ex;
                _startupException = rootCause;
                //Log.Fatal().Log(ex, "Composition error during startup");
            }
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<IShell>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            //Log.Info().Log("Shutting down application");
            base.OnExit(sender, e);
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = String.IsNullOrEmpty(key)
                ? AttributedModelServices.GetContractName(serviceType)
                : key;
            var exports = _container.GetExportedValues<object>(contract);

            var export = exports.FirstOrDefault();
            if (export != null)
                return export;

            throw new InvalidOperationException($"Could not locate any instances of contract {contract}");
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        private void DispatcherShutdownStarted(object sender, EventArgs e)
        {
            //Cleanup only required if initialization actually completed
            if (_container != null)
            {
                AutoResetEvent disposeDoneEvent = new AutoResetEvent(false);
                Task.Run(() =>
                {
                    // Allow up to 10 sec for graceful exit.  If time out occurred, then force kill the app/process
                    var ok = disposeDoneEvent.WaitOne(TimeSpan.FromSeconds(10));
                    if (!ok)
                    {
                        // timed out, force kill
                        Environment.Exit(-1);
                    }
                });

                //Dispose Shell first to allow for cleanup of items requiring deterministic ordering
                var shell = GetAllInstances(typeof(IShell)).OfType<IShell>().SingleOrDefault();
                if (shell != null)
                    shell.Dispose();

                //Cleanup everything else
                _container.Dispose();
                disposeDoneEvent.Set(); // single shutdown success
            }
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return _appAssemblies;
        }
    }

}
