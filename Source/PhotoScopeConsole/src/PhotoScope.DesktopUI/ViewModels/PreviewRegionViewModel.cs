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
        private IPreviewController _previewController;
        private PreviewItem _previewItem;
        private bool _isPreviewLoading;
        private PreviewModel _previewDtoModel;

        public PreviewItem PreviewItem
        {
            get => _previewItem;
            set => SetField(ref _previewItem,value);
        }

        public PreviewModel PreviewDtoModel
        {
            get => _previewDtoModel;
            set => SetField(ref _previewDtoModel,value);
        }

        public bool IsPreviewOpen
        {
            get => _isPreviewLoading;
            set => SetField(ref _isPreviewLoading,value);
        }

        public ICommand ClosePreview { get; set; }
        public ICommand LoadComments { get; set; }


        public PreviewRegionViewModel(IUnityContainer container)
        {
            _previewController = container.Resolve<IPreviewController>();
            _previewController.PreviewLoading += OnPreviewLoading;


            _previewModelProvider = container.Resolve<IModelProvider<PreviewModel>>();
            PreviewDtoModel = _previewModelProvider.GetInitialModel();

            if (PreviewDtoModel != null)
            {
                PreviewItem = PreviewDtoModel.PreviewItem;
            }

            ClosePreview = new Command(OnClosePreviewCommand);
            LoadComments = new Command(OnLoadComments);
        }

        private void OnPreviewLoading(object sender, EventArgs e)
        {
            IsPreviewOpen = true;
        }

        private void OnLoadComments(object obj)
        {
            _previewController.LoadComments();
        }

        private void OnClosePreviewCommand(object obj)
        {
            IsPreviewOpen = false;
            _previewController.ClosePreview();
            
        }
    }
}
