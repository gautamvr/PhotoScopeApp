using System.Configuration;
using System.Reflection;
using System.Windows;
using HostControl.ConsoleUI.ViewModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ServiceAccess.FlickrService.Interfaces;

namespace HostControl.Bootstrapper.AppStart
{
    internal class HostBootstrapper
    {
        private IUnityContainer _container;

        public void Initialize()
        {
            _container = CreateContainer();
            SetupServiceAccess();
            InitializeShell();
        }

        private void SetupServiceAccess()
        {
            var serviceAccess = _container.Resolve<IServiceAccessor>();
            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            var apiKey = configuration.AppSettings.Settings["APIKey"].Value;
            serviceAccess.SetApiKey(apiKey);
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
