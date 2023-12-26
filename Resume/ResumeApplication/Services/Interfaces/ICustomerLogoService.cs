using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerLogo;


namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerLogoService
    {
        Task<CustomerLogo> GetCustomerLogoByID(long id);
        Task<List<CustomerLogoListViewModel>> GetCustomerLogoForIndexPage();
        Task<bool> CreateOrEditCustomerLogo(CreateOrEditCustomerLogoViewModel customerLogo);

        Task<CreateOrEditCustomerLogoViewModel> FillCreateOrEditCustomerLogoViewModel(long id);

        Task<bool> DeleteCustomerLogo(long id);
    }
}
