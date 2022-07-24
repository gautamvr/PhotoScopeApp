using System;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.Core.Interfaces;
using PhotoScope.Utilities.UI.Common;

namespace PreviewDisplay.UI.ViewModel
{
    public class PreviewDisplayViewModel : ViewModelBase
    {
        private IModelProvider<PreviewModel> _previewModelProvider;
        private IPreviewController _previewController;
        private PreviewItem _previewItem;
        private bool _isPreviewLoading;
        private PreviewModel _previewDtoModel;
        private bool _isPreviewOpen;

        public PreviewItem PreviewItem
        {
            get => _previewItem;
            set => SetField(ref _previewItem, value);
        }

        public PreviewModel PreviewDtoModel
        {
            get => _previewDtoModel;
            set => SetField(ref _previewDtoModel, value);
        }
        
        public bool IsPreviewLoading
        {
            get => _isPreviewLoading;
            set => SetField(ref _isPreviewLoading, value);
        }

        public ICommand ClosePreview { get; set; }

        public ICommand LoadComments { get; set; }


        public PreviewDisplayViewModel(IUnityContainer container)
        {
            _previewController = container.Resolve<IPreviewController>();
            _previewController.PreviewLoading += OnPreviewLoading;
            _previewController.PreviewLoaded += OnPreviewLoaded;


            _previewModelProvider = container.Resolve<IModelProvider<PreviewModel>>();
            PreviewDtoModel = _previewModelProvider.GetInitialModel();

            if (PreviewDtoModel != null)
            {
                PreviewItem = PreviewDtoModel.PreviewItem;
            }

            ClosePreview = new Command(OnClosePreviewCommand);
            LoadComments = new Command(OnLoadComments);
        }

        private void OnPreviewLoaded(object sender, EventArgs args)
        {
            IsPreviewLoading = false;
        }

        private void OnPreviewLoading(object sender, EventArgs e)
        {
            IsPreviewLoading = true;
        }

        private void OnLoadComments(object obj)
        {
            _previewController.LoadComments();
        }

        private void OnClosePreviewCommand(object obj)
        {
            _previewController.ClosePreview();
        }
    }
}
