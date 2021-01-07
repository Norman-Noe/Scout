using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Scout.UI.ViewModels
{
    public class ApplicationInstance : BaseVM, IApplicationInstance
    {
        public BaseVM CurrentPage { get; set; }

        public ICommand UpdateMWCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ApplicationInstance()
        {
            CurrentPage = new FrontPageVM();
            UpdateMWCommand = new RelayCommand<ApplicationPage>(GoToPage);
            CloseCommand = new RelayCommand<Window>(CloseWindow);
        }

        public void GoToPage(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.FrontPage:
                    CurrentPage = new FrontPageVM();
                    break;
                case ApplicationPage.GeneralInfo:
                    CurrentPage = new GeneralInfoVM();
                    break;
            }
        }

        public void CloseWindow(Window windowtoclose)
        {
            windowtoclose.Close();
        }
    }
}
