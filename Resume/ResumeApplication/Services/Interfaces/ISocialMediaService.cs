using Resume.Domain.Models;
using Resume.Domain.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface ISocialMediaService
    {
        Task<SocialMedia> GetSocialMediaByID(long id);

        Task<List<SocialMediaViewModel>> GetAllSocialMedias();

        Task<bool> CreateOrEditSocialMedia(CreateOrEditSocialMediaViewModel socialMedia);
        Task<bool> DeleteSocialMedia(long id);
        Task<CreateOrEditSocialMediaViewModel> FillCreateOrEditSocialMediaViewModel(long id);
    }
}
