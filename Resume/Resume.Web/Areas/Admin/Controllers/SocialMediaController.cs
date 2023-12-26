using Microsoft.AspNetCore.Mvc;
using Resume.Domain.ViewModels.SocialMedia;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class SocialMediaController : AdminBaseController
    {

        #region Constructor

        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _socialMediaService.GetAllSocialMedias());
        }

        public async Task<IActionResult> LoadSocialMediaFormModal(long id)
        {
            CreateOrEditSocialMediaViewModel result = await _socialMediaService.FillCreateOrEditSocialMediaViewModel(id);
            return PartialView("_SocialMediaFormModalPartial", result);

        }

        public async Task<IActionResult> SubmitSocialMediaFormModal(CreateOrEditSocialMediaViewModel socialMedia)
        {
            var result = await _socialMediaService.CreateOrEditSocialMedia(socialMedia);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }


        public async Task<IActionResult> DeleteSocialMedia(long id)
        {
            var result = await _socialMediaService.DeleteSocialMedia(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });

        }

    }
}
