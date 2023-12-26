using Microsoft.AspNetCore.Mvc;
using Resume.Domain.ViewModels.ThingIDo;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ThingIDoController : AdminBaseController
    {

        #region Constructor
        private readonly IThingIDoService _thingIDoService;

        public ThingIDoController(IThingIDoService thingIDoService)
        {
            _thingIDoService = thingIDoService;
        }

        #endregion


        #region List
        public async Task<IActionResult> Index()
        {
            return View(await _thingIDoService.GetAllThingIDoForIndex());
        }
        #endregion



        public async Task<IActionResult> LoadThingIDoFormModal(long id)
        {
            CreateOrEditThingIDoViewModel result = await _thingIDoService.FillCreateOrEditThingIDoViewModel(id);

            return PartialView("_ThingIDoFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitThingIDoFormModal(CreateOrEditThingIDoViewModel thingIDo)
        {
            var result = await _thingIDoService.CreateOrEditThingIDo(thingIDo);

            if (result) return new JsonResult(new { status = "Success" });
            
            return new JsonResult(new { status = "Error" });
        }


        public async Task<IActionResult> DeleteThingIDo(long id)
        {
            var result = await _thingIDoService.DeleteThingIDo(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });

        }

    }
}
