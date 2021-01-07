using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Scout.UI.ViewModels
{
    public interface IApplicationInstance
    {
        BaseVM CurrentPage { get; set; }
        void GoToPage(ApplicationPage page);
        ICommand UpdateMWCommand { get; set; }
    }
}
