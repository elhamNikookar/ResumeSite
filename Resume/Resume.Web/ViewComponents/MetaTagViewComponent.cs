using Microsoft.AspNetCore.Mvc;
using Resume.Domain.ViewModels.MetaTagSeo;
using Resume.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace Resume.Web.ViewComponents
{
    public class MetaTagViewComponent : ViewComponent
    {
        #region Constructor
        private readonly IMetaTagSeoService _metaTagSeoService;

        public MetaTagViewComponent(IMetaTagSeoService metaTagSeoService)
        {
            _metaTagSeoService = metaTagSeoService;
        }
        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            MetaTagSeoViewModel model = await _metaTagSeoService.GetMetaTagSeoModel();

            return View("MetaTag" , model);
        }
    }
}
