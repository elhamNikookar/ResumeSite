using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;


namespace Resume.Application.Services.Implementations
{
    public class CustomerLogoService : ICustomerLogoService
    {
        #region Constructor
        private readonly AppDbContext _context;
        public CustomerLogoService(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        public async Task<CustomerLogo> GetCustomerLogoByID(long id)
        {
            return await _context.CustomerLogos.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<List<CustomerLogoListViewModel>> GetCustomerLogoForIndexPage()
        {
            List<CustomerLogoListViewModel> customerLogos = await _context.CustomerLogos
                .OrderBy(c=> c.Order)
                .Select(c=>new CustomerLogoListViewModel()
                {
                    ID = c.ID,
                    Link = c.Link,
                    Logo = c.Logo,
                    LogoAlt = c.LogoAlt,
                    Order = c.Order 
             
                })
                .ToListAsync();

            return customerLogos;

        }



        public async Task<bool> CreateOrEditCustomerLogo(CreateOrEditCustomerLogoViewModel customerLogo)
        {
            //create
            if (customerLogo.ID == 0)
            {
                CustomerLogo newCustomerLogo = new CustomerLogo()
                {
                    Link = customerLogo.Link,
                    Logo = customerLogo.Logo,
                    LogoAlt= customerLogo.LogoAlt,
                    Order = customerLogo.Order
                };

                await _context.CustomerLogos.AddAsync(newCustomerLogo);
                await _context.SaveChangesAsync();
                return true;
            }

            //edit
            CustomerLogo currentCustomerLogo = await GetCustomerLogoByID(customerLogo.ID);

            if (currentCustomerLogo == null) return false;

            currentCustomerLogo.Logo = customerLogo.Logo;
            currentCustomerLogo.LogoAlt = customerLogo.LogoAlt;
            currentCustomerLogo.Order = customerLogo.Order;
            currentCustomerLogo.Link = customerLogo.Link;

            _context.CustomerLogos.Update(currentCustomerLogo);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<CreateOrEditCustomerLogoViewModel> FillCreateOrEditCustomerLogoViewModel(long id)
        {
            if (id == 0) return new CreateOrEditCustomerLogoViewModel() { ID = 0 };

            CustomerLogo customerLogo = await GetCustomerLogoByID(id);

            if (customerLogo == null) return new CreateOrEditCustomerLogoViewModel() { ID = 0 };

            return new CreateOrEditCustomerLogoViewModel()
            {
                ID = customerLogo.ID,
                Link = customerLogo.Link,
                Logo = customerLogo.Logo,
                LogoAlt = customerLogo.LogoAlt,
                Order = customerLogo.Order
            };
        }

        public async Task<bool> DeleteCustomerLogo(long id)
        {
            CustomerLogo customerLogo = await GetCustomerLogoByID(id);

            if (customerLogo == null) return false;

            _context.CustomerLogos.Remove(customerLogo);
            await _context.SaveChangesAsync();

            return true;

        }


    }
}
