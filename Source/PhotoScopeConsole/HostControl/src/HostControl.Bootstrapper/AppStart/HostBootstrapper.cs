using System.Configuration;
using System.Reflection;
using System.Windows;
using HostControl.ConsoleUI.ViewModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ServiceAccess.FlickrService.Interfaces;

namespace HostControl.Bootstrapper.AppStart
{
    /// <summary>
    /// The bootstrapper class
    /// </summary>
    public class HostBootstrapper
    {
        private IUnityContainer _container;

        public void Initialize()
        {
            _container = CreateContainer();
            SetupServiceAccess();
            InitializeShell();
        }

        /// <summary>
        /// Sets up the Service accessor with the API Key
        /// </summary>
        private void SetupServiceAccess()
        {
            var serviceAccess = _container.Resolve<IServiceAccessor>();
            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            var apiKey = configuration.AppSettings.Settings["APIKey"].Value;
            var cacheVal = configuration.AppSettings.Settings["CacheEnabled"].Value;
            var cacheCapacityVal = configuration.AppSettings.Settings["CacheCapacity"].Value;

            bool.TryParse(cacheVal, out bool isCacheEnabled);
            int.TryParse(cacheCapacityVal, out int cacheCapacity);
            
            serviceAccess.SetApiKey(apiKey);
            serviceAccess.SetupCacheStore(isCacheEnabled,cacheCapacity);
        }

        /// <summary>
        /// Loads the configuration from the Unity file
        /// </summary>
        /// <param name="container"></param>
        private void LoadConfiguration(IUnityContainer container)
        {
            var configuration =
                ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var unityConfigurationSection = (UnityConfigurationSection)configuration.GetSection("unity");
            container.LoadConfiguration(unityConfigurationSection);
        }

        /// <summary>
        /// Creates a container
        /// </summary>
        /// <returns></returns>
        protected IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            LoadConfiguration(container);
            return container;
        }

        /// <summary>
        /// Initializes the Shell window
        /// </summary>
        protected void InitializeShell()
        {
            Application.Current.MainWindow = _container.Resolve<Window>();
            Application.Current.MainWindow.DataContext = _container.Resolve<PhotoScopeConsoleViewModel>();
            Application.Current.MainWindow?.Show();
        }
    }
}
