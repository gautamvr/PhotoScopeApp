using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PhotoScope.DesktopUI.AppStart;

namespace PhotoScope.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ConsoleBootstrapper _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper = new ConsoleBootstrapper();
            _bootstrapper.Initialize();
        }
    }
}
