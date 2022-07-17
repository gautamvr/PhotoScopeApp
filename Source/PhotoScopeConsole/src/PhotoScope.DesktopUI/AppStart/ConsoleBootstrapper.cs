using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
        private void LoadConfiguration(IUnityContainer container)
        {
            var configuration =
                ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var unityConfigurationSection = (UnityConfigurationSection)configuration.GetSection("unity");
            container.LoadConfiguration(unityConfigurationSection);
        }

        protected override IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            LoadConfiguration(container);
            return container;
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
