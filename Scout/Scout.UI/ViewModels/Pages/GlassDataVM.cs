using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Scout.UI.ViewModels
{
    public class GlassDataVM : BaseVM
    {
        public ICommand GoToNewViewCommand { get; set; }

        public GlassDataVM()
        {
            this.GoToNewViewCommand = new RelayCommand<ApplicationPage>(GoToViewCommand.GoToPageWrapper);
        }
    }
}
