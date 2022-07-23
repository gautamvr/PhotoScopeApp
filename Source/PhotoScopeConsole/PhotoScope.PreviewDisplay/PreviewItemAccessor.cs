using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PhotoScope.Core.DTOModels;
using PhotoScope.PreviewDisplay.Interfaces;
using PhotoScope.ServiceAccessLayer.Data;
using PhotoScope.ServiceAccessLayer.Interfaces;
using static System.Int32;

namespace PhotoScope.PreviewDisplay
{
    public class PreviewItemAccessor : IPreviewItemAccessor
    {
        private IServiceAccessor _serviceAccessor;
        private IPreviewPopulator _previewPopulator;


        public PreviewItemAccessor(IUnityContainer container)
        {
            _serviceAccessor = container.Resolve<IServiceAccessor>();
            _previewPopulator = container.Resolve<IPreviewPopulator>();
        }

        public async Task<PreviewItem> GetPreviewItem(string imageId)
        {
            var item = await Task.Run(() => _serviceAccessor.GetPhotoInfoAsync(imageId));

            return CreatePreviewModel(item);

        }
        public async Task<IEnumerable<CommentItem>> GetCommentSection(string imageId)
        {
            var commentsResult = await Task.Run(() => _serviceAccessor.GetCommentsAsync(imageId));

            return GetComments(commentsResult);
        }

        private PreviewItem CreatePreviewModel(PhotoInfo photoInfoModel)
        {
            PreviewItem previewModel = new PreviewItem();
            if (photoInfoModel != null)
            {
                previewModel.PreviewItemOwner = CreatePreviewItemOwner(photoInfoModel.Owner);
                previewModel.NumOfComments = Parse(photoInfoModel.Comments._content);
                previewModel.CommentsList = new ObservableCollection<Core.DTOModels.CommentItem>();
                previewModel.Title = photoInfoModel.Title._content;
                previewModel.Description = photoInfoModel.Description._content;
                previewModel.Views = photoInfoModel.Views;
                previewModel.ImageId = photoInfoModel.Id;
                previewModel.ImageUrl = 
                    _serviceAccessor.GetImageUrl(photoInfoModel.Server, photoInfoModel.Id, photoInfoModel.Secret);

            }

            return previewModel;
        }

        private PreviewItemOwner CreatePreviewItemOwner(OwnerInfo ownerInfo)
        {
            PreviewItemOwner previewOwner = new PreviewItemOwner();
            if (ownerInfo != null)
            {
                previewOwner.FullName = ownerInfo.RealName;
                previewOwner.UserName = ownerInfo.UserName;
                previewOwner.Location = ownerInfo.Location;
                previewOwner.DisplayPhotoUrl =
                    _serviceAccessor.GetBuddyIconUrl(ownerInfo.IconFarm, ownerInfo.IconServer, ownerInfo.Nsid);
            }
            return previewOwner;
        }

        private IEnumerable<CommentItem> GetComments(Comments commentsResult)
        {
            if (commentsResult != null)
            {
                foreach (var comment in commentsResult.Comment)
                {
                    if (comment != null)
                    {
                        yield return CreateNewCommentItem(comment);
                    }
                    
                }

            }
        }

        private CommentItem CreateNewCommentItem(Comment comment)
        {
            try
            {
                CommentItem previewCommentItem = new CommentItem();
                previewCommentItem.Content = comment._content;
                previewCommentItem.AuthorName = comment.AuthorName;
                previewCommentItem.IsAuthorDeleted = comment.Author_Is_Deleted;
                previewCommentItem.DateCreated = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(comment.DateCreate)).DateTime;
                previewCommentItem.AuthorIconUrl =
                    _serviceAccessor.GetBuddyIconUrl(comment.IconFarm.ToString(), comment.IconServer, comment.Author);


                return previewCommentItem;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
