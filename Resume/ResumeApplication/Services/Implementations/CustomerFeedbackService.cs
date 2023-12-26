using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class CustomerFeedbackService : ICustomerFeedbackService
    {
        #region Constructor
        private readonly AppDbContext _context;
        public CustomerFeedbackService(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        public async Task<CustomerFeedback> GetCustomerFeedbackByID(long id)
        {
            return await _context.CustomerFeedbacks.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<List<CustomerFeedbackViewModel>> GetCustomerFeedbackForIndex()
        {
            List<CustomerFeedbackViewModel> customerFeedbacks = await _context.CustomerFeedbacks
                .OrderBy(c => c.Order)
                .Select(c => new CustomerFeedbackViewModel()
                {
                    Order = c.Order,
                    Avatar = c.Avatar,
                    Description = c.Description,
                    Name = c.Name,
                    ID = c.ID,
                })
                .ToListAsync();

            return customerFeedbacks;
        }

        public async Task<bool> CreateOrEditCustomerFeedback(CreateOrEditCustomerFeedbackViewModel customerFeedback)
        {
            //create
            if(customerFeedback.ID == 0)
            {
                CustomerFeedback newCustomerFeedback = new CustomerFeedback()
                {
                    Avatar = customerFeedback.Avatar,
                    Description = customerFeedback.Description,
                    Name = customerFeedback.Name,
                    Order = customerFeedback.Order
                };

                await _context.CustomerFeedbacks.AddAsync(newCustomerFeedback);
                await _context.SaveChangesAsync();
                return true;
            }

            //edit
            CustomerFeedback currentCustomerFeedback = await GetCustomerFeedbackByID(customerFeedback.ID);
          
            if(currentCustomerFeedback == null) return false;

            currentCustomerFeedback.Avatar = customerFeedback.Avatar;
            currentCustomerFeedback.Name = customerFeedback.Name;
            currentCustomerFeedback.Order = customerFeedback.Order;
            currentCustomerFeedback.Description = customerFeedback.Description;

            _context.CustomerFeedbacks.Update(currentCustomerFeedback);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<CreateOrEditCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(long id)
        {
            if (id == 0) return new CreateOrEditCustomerFeedbackViewModel() { ID = 0 };

            CustomerFeedback customerFeedback = await GetCustomerFeedbackByID(id);

            if (customerFeedback == null) return new CreateOrEditCustomerFeedbackViewModel() { ID = 0 };

            return new CreateOrEditCustomerFeedbackViewModel()
            {
                ID = customerFeedback.ID,
                Name = customerFeedback.Name,
                Avatar = customerFeedback.Avatar,
                Order = customerFeedback.Order,
                Description = customerFeedback.Description
            };
        }

        public async Task<bool> DeleteCustomerFeedback(long id)
        {
            CustomerFeedback customerFeedback = await GetCustomerFeedbackByID(id);

            if(customerFeedback == null) return false;

            _context.CustomerFeedbacks.Remove(customerFeedback);
            await _context.SaveChangesAsync();

            return true;

        }

    }

}
