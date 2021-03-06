using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HostControl.ConsoleUI.View
{
    /// <summary>
    /// Interaction logic for PhotoScopeConsoleView.xaml
    /// </summary>
    public partial class PhotoScopeConsoleView : UserControl
    {
        public PhotoScopeConsoleView()
        {
            ApplyTheme();
            InitializeComponent();
        }

        private void ApplyTheme()
        {
            var themeUri = new Uri("HostControl.ConsoleUI;component/Themes/Generic.xaml",
                UriKind.RelativeOrAbsolute);
            if (Application.Current.Resources.MergedDictionaries.All(x => x.Source != themeUri))
            {
                var themeDictionary = new ResourceDictionary
                {
                    Source = themeUri
                };
                Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
            }
        }
    }
}
