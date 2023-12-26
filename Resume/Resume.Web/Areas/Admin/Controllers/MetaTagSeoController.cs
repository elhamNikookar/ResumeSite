using Microsoft.AspNetCore.Mvc;
using Resume.Application.Extensions;
using Resume.Application.Generator;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.MetaTagSeo;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class MetaTagSeoController : AdminBaseController
    {

        #region Constructor

        private readonly IMetaTagSeoService _metaTagSeoService;
        #endregion

        public async Task<IActionResult> LoadMetaTagSeoFormModal()
        {
            CreateOrEditMetaTagSeoViewModel result = await _metaTagSeoService.FillCreateOrEditMetaTagSeoViewModel();
            return PartialView("_MetaTagSeoFormModalPartial", result);

        }

        public async Task<IActionResult> SubmitMetaTagSeoFormModal(CreateOrEditMetaTagSeoViewModel metaTagSeo)
        {
            var result = await _metaTagSeoService.CreateOrEditMetaTagSeo(metaTagSeo);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }


        [HttpPost]
        public async Task<IActionResult> UploadMetaTagSeoImageAjax(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.TwitterImageServer);
                    return new JsonResult(new { status = "Success", imageName = imageName });
                }
                else
                {
                    return new JsonResult(new { status = "Error" });
                }
            }
            else
            {
                return new JsonResult(new { status = "Error" });
            }
        }

    }
}
