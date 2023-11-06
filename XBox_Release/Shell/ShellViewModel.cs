using Prism.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBox
{
    [Export(typeof(IShell))]
    public sealed class ShellViewModel : IShell
    {
        private readonly IMainViewModel _mainViewModel;
        public IMainViewModel MainViewModel
        {
            get { return _mainViewModel; }
        }

        [ImportingConstructor]
        public ShellViewModel(IMainViewModel mainViewModel)
        //public ShellViewModel()
        {
            _mainViewModel = mainViewModel;
            //mainViewModel.ShowMessage("Hello1234");
        }
        public void Dispose()
        {
            System.Diagnostics.Debug.WriteLine("Hello");
        }


    }
 }
