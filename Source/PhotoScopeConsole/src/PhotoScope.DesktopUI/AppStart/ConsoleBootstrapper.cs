using System.Configuration;
using System.Reflection;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PhotoScope.DesktopUI.ViewModels;
using Prism.Unity;

namespace PhotoScope.DesktopUI.AppStart
{
    internal class ConsoleBootstrapper
    {
        private IUnityContainer _container;
        
        public void Initialize()
        {
            _container = CreateContainer();
            InitializeShell();
        }

        private void LoadConfiguration(IUnityContainer container)
        {
            var configuration =
                ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var unityConfigurationSection = (UnityConfigurationSection)configuration.GetSection("unity");
            container.LoadConfiguration(unityConfigurationSection);
        }

        protected IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            LoadConfiguration(container);
            container.RegisterType<PhotoFeedViewModel>(new ContainerControlledLifetimeManager());
            return container;
        }
        
        protected void InitializeShell()
        {
            Application.Current.MainWindow = _container.Resolve<Window>();
            Application.Current.MainWindow.DataContext = _container.Resolve<PhotoScopeConsoleViewModel>();
            Application.Current.MainWindow?.Show();
        }
    }
}
