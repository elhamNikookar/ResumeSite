using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Portfolio;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {

        #region Constructor
        private readonly AppDbContext _context;

        public PortfolioService(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Portfolio

        public async Task<Portfolio> GetPortfolioById(long id)
        {
            return await _context.Portfolios.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<List<PortfolioViewModel>> GetAllPortfolios()
        {
            List<PortfolioViewModel> portfolios = await _context.Portfolios
                .OrderBy(p => p.Order)
                .Select(p => new PortfolioViewModel()
                {
                    ID = p.ID,
                    Image = p.Image,
                    ImageAlt = p.ImageAlt,
                    Link = p.Link,
                    Order = p.Order,
                    PortfolioCategoryTitle = p.PortfolioCategory.Name,
                    Title = p.Title
                })
                .ToListAsync();

            return portfolios;
        }


        public async Task<CreateOrEditPortfolioViewModel> FillCreateOrEditPortfolioViewModel(long id)
        {
            if (id == 0) return new CreateOrEditPortfolioViewModel()
            {
                ID = 0,
                PortfolioCategories = await GetAllPortfolioCategories()
            };

            Portfolio portfolio = await GetPortfolioById(id);
            if (portfolio == null) return new CreateOrEditPortfolioViewModel()
            {
                ID = 0,
                PortfolioCategories = await GetAllPortfolioCategories()
            };

            return new CreateOrEditPortfolioViewModel()
            {
                ID = portfolio.ID,
                ImageAlt = portfolio.ImageAlt,
                Image = portfolio.Image,
                Link = portfolio.Link,
                Order = portfolio.Order,
                Title = portfolio.Title,
                PortfolioCategoryID = portfolio.PortfolioCategoryID,
                PortfolioCategories = await GetAllPortfolioCategories()
            };
             
        }

        public async Task<bool> CreateOrEditPortfolio(CreateOrEditPortfolioViewModel portfolio)
        {
            //Create
            if(portfolio.ID == 0)
            {
                Portfolio newPortfolio = new Portfolio()
                {
                    ImageAlt = portfolio.ImageAlt,
                    Image = portfolio.Image,
                    Link = portfolio.Link,
                    Order = portfolio.Order,
                    Title = portfolio.Title,
                    PortfolioCategoryID = portfolio.PortfolioCategoryID
                };

                await _context.AddAsync(newPortfolio);
                await _context.SaveChangesAsync();
                return true;
            } 

            Portfolio currentPortfolio = await GetPortfolioById(portfolio.ID);

            if(currentPortfolio == null) return false;

            //Edit
            currentPortfolio.Title = portfolio.Title;
            currentPortfolio.Link = portfolio.Link;
            currentPortfolio.ImageAlt = portfolio.ImageAlt;
            currentPortfolio.Image = portfolio.Image;
            currentPortfolio.Order = portfolio.Order;
            currentPortfolio.PortfolioCategoryID = portfolio.PortfolioCategoryID;

            _context.Portfolios.Update(currentPortfolio);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePortfolio(long id)
        {
            Portfolio portfolio = await GetPortfolioById(id);

            if (portfolio == null) return false;

            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return true;
        }


        #endregion



        #region Portfolio Category
        public async Task<PortfolioCategory> GetPortfolioCategoryById(long id)
        {
            return await _context.PortfoliosCategories.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<List<PortfolioCategoryViewModel>> GetAllPortfolioCategories()
        {
            List<PortfolioCategoryViewModel> portfolioCategories = await _context.PortfoliosCategories
                .OrderBy(pc => pc.Order)
                .Select(pc => new PortfolioCategoryViewModel()
                {
                    ID = pc.ID,
                    Name = pc.Name,
                    Order = pc.Order,
                    Title = pc.Title
                })
                .ToListAsync();

            return portfolioCategories;
        }

        public async Task<CreateOrEditPortfolioCategoryViewModel> FillCreateOrEditPortfolioCategoryViewModel(long id)
        {
            if (id == 0) return new CreateOrEditPortfolioCategoryViewModel() { ID = 0 };

            PortfolioCategory portfolioCategory = await GetPortfolioCategoryById(id);

            if (portfolioCategory == null) return new CreateOrEditPortfolioCategoryViewModel() { ID = 0 };

            return new CreateOrEditPortfolioCategoryViewModel() {
            ID = portfolioCategory.ID,
            Name = portfolioCategory.Name,
            Order = portfolioCategory.Order,
            Title = portfolioCategory.Title
            };
        }

        public async Task<bool> CreateOrEditPortfolioCategory(CreateOrEditPortfolioCategoryViewModel portfolioCategory)
        {

            if (portfolioCategory.ID == 0)
            {
                var newPortfolioCategory = new PortfolioCategory()
                {
                    Name = portfolioCategory.Name,
                    Order = portfolioCategory.Order,
                    Title = portfolioCategory.Title
                };

                await _context.PortfoliosCategories.AddAsync(newPortfolioCategory);
                await _context.SaveChangesAsync();
                return true;
            }

            PortfolioCategory currentPortfolioCategory = await GetPortfolioCategoryById(portfolioCategory.ID);

            if (currentPortfolioCategory == null) return false;

            currentPortfolioCategory.Name = portfolioCategory.Name;
            currentPortfolioCategory.Order = portfolioCategory.Order;
            currentPortfolioCategory.Title = portfolioCategory.Title;

            _context.PortfoliosCategories.Update(currentPortfolioCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePortfolioCategory(long id)
        {
            PortfolioCategory portfolioCategory = await GetPortfolioCategoryById(id);

            if (portfolioCategory == null) return false;

            _context.PortfoliosCategories.Remove(portfolioCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion


    }
}
