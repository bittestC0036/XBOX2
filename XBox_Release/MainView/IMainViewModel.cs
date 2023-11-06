using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBox
{
    public interface IMainViewModel
    {
        void Window_Loaded(object dataContext);

        void Btn_SetPath();

        void FindFileName();
    }
}
