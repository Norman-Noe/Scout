using System;
using System.Collections.Generic;
using System.Text;
using Scout.UI.ViewModels;

namespace Scout.UI
{
    public static class GoToViewCommand
    {
        public static void GoToPageWrapper(ApplicationPage page)
        {
            IoC.Application.GoToPage(page);
        }
    }
}
