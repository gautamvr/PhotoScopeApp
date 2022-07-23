using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.ViewModels
{
    public class PreviewRegionViewModel : ViewModelBase
    {
        private IModelProvider<PreviewModel> _previewModelProvider;
        private PreviewModel _previewItem;

        public PreviewModel PreviewItem
        {
            get => _previewItem;
            set => SetField(ref _previewItem,value);
        }

        public ICommand ClosePreview { get; set; }
        public ICommand LoadComments { get; set; }


        public PreviewRegionViewModel(IUnityContainer container)
        {
            _previewModelProvider = container.Resolve<IModelProvider<PreviewModel>>();
            PreviewItem = _previewModelProvider.GetInitialModel();

        }
    }
}
