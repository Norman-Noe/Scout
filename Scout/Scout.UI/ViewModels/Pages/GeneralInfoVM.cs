using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Scout.UI.ViewModels
{
    public class GeneralInfoVM : BaseVM
    {
        public ICommand GoToNewViewCommand { get; set; }

        public GeneralInfoVM()
        {
            this.GoToNewViewCommand = new RelayCommand<ApplicationPage>(GoToViewCommand.GoToPageWrapper);
        }
    }
}
