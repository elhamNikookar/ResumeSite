using Microsoft.AspNetCore.Mvc;
using Resume.Domain.ViewModels.ViewComponent;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.ViewComponents
{
    public class SideBarViewComponent :ViewComponent
    {
        #region
        private readonly ISocialMediaService _socialMediaService;
        private readonly IInformationService _informationService;


        public SideBarViewComponent(ISocialMediaService socialMediaService , IInformationService informationService)
        {
            _socialMediaService = socialMediaService;  
            _informationService = informationService;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SideBarViewModel model = new SideBarViewModel()
            {
                SocialMedias = await _socialMediaService.GetAllSocialMedias() ,
                Information = await _informationService.GetInformation()
            };

            return View("SideBar" , model);
        }

    }
}
