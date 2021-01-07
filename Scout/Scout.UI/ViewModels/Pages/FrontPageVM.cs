using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Scout.UI.ViewModels
{
    public class FrontPageVM : BaseVM
    {
        public ICommand GoToNewViewCommand { get; set; }

        public FrontPageVM()
        {
            this.GoToNewViewCommand = new RelayCommand<ApplicationPage>(GoToViewCommand.GoToPageWrapper);
        }
    }
}
