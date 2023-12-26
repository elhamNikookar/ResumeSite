using Microsoft.AspNetCore.Mvc;
using Resume.Application.Extensions;
using Resume.Application.Generator;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class CustomerLogoController : AdminBaseController
    {
        #region Constructor

        private readonly ICustomerLogoService _customerLogoService;

        public CustomerLogoController(ICustomerLogoService customerLogoService)
        {
            _customerLogoService = customerLogoService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _customerLogoService.GetCustomerLogoForIndexPage());
        }

        public async Task<IActionResult> LoadCustomerLogoFormModal(long id)
        {
            CreateOrEditCustomerLogoViewModel result = await _customerLogoService.FillCreateOrEditCustomerLogoViewModel(id);
            return PartialView("_CustomerLogoFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitCustomerLogoFormModal(CreateOrEditCustomerLogoViewModel customerLogo)
        {
            var result = await _customerLogoService.CreateOrEditCustomerLogo(customerLogo);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteCustomerLogoFormModal(long id)
        {
            var result = await _customerLogoService.DeleteCustomerLogo(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }


        [HttpPost]
        public async Task<IActionResult> UploadCustomerLogoImageAjax(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.CustomerLogoServer);
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
