using Microsoft.AspNetCore.Mvc;
using Resume.Domain.ViewModels.Page;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Controllers
{
    public class PortfolioController : Controller
    {

        #region Constructor
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        #endregion


        public async Task<IActionResult> Index()
        {
            PortfolioPageViewModel model = new PortfolioPageViewModel()
            {
                Portfolios = await _portfolioService.GetAllPortfolios(),
                PortfolioCategories = await _portfolioService.GetAllPortfolioCategories()
            };

            return View(model);
        }
    }
}
