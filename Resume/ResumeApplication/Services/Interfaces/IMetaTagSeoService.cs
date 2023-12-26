using Resume.Domain.Models;
using Resume.Domain.ViewModels.MetaTagSeo;


namespace Resume.Application.Services.Interfaces
{
    public interface IMetaTagSeoService
    {
        Task<MetaTagSeo> GetMetaTagSeo();
        Task<MetaTagSeoViewModel> GetMetaTagSeoModel();

        Task<CreateOrEditMetaTagSeoViewModel> FillCreateOrEditMetaTagSeoViewModel();

        Task<bool> CreateOrEditMetaTagSeo(CreateOrEditMetaTagSeoViewModel metaTagSeo);

    }
}
