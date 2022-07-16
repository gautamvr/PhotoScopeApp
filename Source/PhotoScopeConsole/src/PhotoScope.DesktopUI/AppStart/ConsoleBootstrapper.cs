using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PhotoScope.DesktopUI.ViewModels;
using Prism.Unity;

namespace PhotoScope.DesktopUI.AppStart
{
    internal class ConsoleBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            var container = Container;
            container.LoadConfiguration();
        }

        protected override IUnityContainer CreateContainer()
        {
            return new UnityContainer();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<Window>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = Shell as Window;
            Application.Current.MainWindow.DataContext = Container.Resolve<PhotoScopeConsoleViewModel>();
            Application.Current.MainWindow?.Show();
        }
    }
}
