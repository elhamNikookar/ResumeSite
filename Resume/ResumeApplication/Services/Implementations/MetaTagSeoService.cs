using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.MetaTagSeo;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;

namespace Resume.Application.Services.Implementations
{
    public class MetaTagSeoService : IMetaTagSeoService
    {
        #region Constructor
        private readonly AppDbContext _context;

        public MetaTagSeoService(AppDbContext context)
        {
            _context = context;
        }

        #endregion


        public async Task<MetaTagSeo> GetMetaTagSeo()
        {
            return await _context.MetaTagsSeo.FirstOrDefaultAsync();
        }

        public async Task<MetaTagSeoViewModel> GetMetaTagSeoModel()
        {
            MetaTagSeoViewModel metaTagSeo = await _context.MetaTagsSeo
                .Select(x => new MetaTagSeoViewModel()
                {
                    ID = x.ID,
                    Keywords = x.Keywords,
                    Description = x.Description,
                    RefreshTime = x.RefreshTime,
                    Author = x.Author,

                    OgDescription = x.OgDescription,
                    OgImage = x.OgImage,
                    OgLocale = x.OgLocale,
                    OgTitle = x.OgTitle,
                    OgType = x.OgType,
                    OgUrl = x.OgUrl,

                    TwitterDescription = x.TwitterDescription,
                    TwitterImage = x.TwitterImage,
                    TwitterTitle = x.TwitterTitle,
                    TwitterUrl = x.TwitterUrl
                })
                .FirstOrDefaultAsync();

            return metaTagSeo;
        }


        public async Task<bool> CreateOrEditMetaTagSeo(CreateOrEditMetaTagSeoViewModel metaTagSeo)
        {
            //Create 
            if (metaTagSeo.ID == 0)
            {
                MetaTagSeo newMetaTagSeo = new MetaTagSeo()
                {
                    Keywords = metaTagSeo.Keywords,
                    Description = metaTagSeo.Description,
                    RefreshTime = metaTagSeo.RefreshTime,
                    Author = metaTagSeo.Author,

                    OgDescription = metaTagSeo.OgDescription,
                    OgImage = metaTagSeo.OgImage,
                    OgLocale = metaTagSeo.OgLocale,
                    OgTitle = metaTagSeo.OgTitle,
                    OgType = metaTagSeo.OgType,
                    OgUrl = metaTagSeo.OgUrl,

                    TwitterDescription = metaTagSeo.TwitterDescription,
                    TwitterImage = metaTagSeo.TwitterImage,
                    TwitterTitle = metaTagSeo.TwitterTitle,
                    TwitterUrl = metaTagSeo.TwitterUrl
                };

                await _context.AddAsync(newMetaTagSeo);
                await _context.SaveChangesAsync();
                return true;
            }

                //Edit
                MetaTagSeo currentMetaTagSeo = await GetMetaTagSeo();

                currentMetaTagSeo.Keywords = metaTagSeo.Keywords;
                currentMetaTagSeo.Description = metaTagSeo.Description;
                currentMetaTagSeo.RefreshTime = metaTagSeo.RefreshTime;
                currentMetaTagSeo.Author = metaTagSeo.Author;

                currentMetaTagSeo.OgDescription = metaTagSeo.OgDescription;
                currentMetaTagSeo.OgImage = metaTagSeo.OgImage;
                currentMetaTagSeo.OgLocale = metaTagSeo.OgLocale;
                currentMetaTagSeo.OgTitle = metaTagSeo.OgTitle;
                currentMetaTagSeo.OgType = metaTagSeo.OgType;
                currentMetaTagSeo.OgUrl = metaTagSeo.OgUrl;

                currentMetaTagSeo.TwitterDescription = metaTagSeo.TwitterDescription;
                currentMetaTagSeo.TwitterImage = metaTagSeo.TwitterImage;
                currentMetaTagSeo.TwitterTitle = metaTagSeo.TwitterTitle;
                currentMetaTagSeo.TwitterUrl = metaTagSeo.TwitterUrl;

                _context.MetaTagsSeo.Update(currentMetaTagSeo);
                await _context.SaveChangesAsync();
                return true;

        }


        public async Task<CreateOrEditMetaTagSeoViewModel> FillCreateOrEditMetaTagSeoViewModel()
        {
            MetaTagSeo metaTagSeo = await GetMetaTagSeo();

            if (metaTagSeo == null) return new CreateOrEditMetaTagSeoViewModel() { ID = 0 };

            return new CreateOrEditMetaTagSeoViewModel()
            {
                ID = metaTagSeo.ID,
                Keywords = metaTagSeo.Keywords,
                Description = metaTagSeo.Description,
                RefreshTime = metaTagSeo.RefreshTime,
                Author = metaTagSeo.Author,

                OgDescription = metaTagSeo.OgDescription,
                OgImage = metaTagSeo.OgImage,
                OgLocale = metaTagSeo.OgLocale,
                OgTitle = metaTagSeo.OgTitle,
                OgType = metaTagSeo.OgType,
                OgUrl = metaTagSeo.OgUrl,

                TwitterDescription = metaTagSeo.TwitterDescription,
                TwitterImage = metaTagSeo.TwitterImage,
                TwitterTitle = metaTagSeo.TwitterTitle,
                TwitterUrl = metaTagSeo.TwitterUrl

            };
        }
        
    }
}
