using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Text;
using Scout.UI.ViewModels;

namespace Scout.UI
{
    public static class IoC
    {
        public static WindsorContainer Container { get; set; }
        public static IApplicationInstance Application { get; set; }
        static IoC()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For<IApplicationInstance>().ImplementedBy<ApplicationInstance>());
            Application = Container.Resolve<IApplicationInstance>();
        }
    }
}
