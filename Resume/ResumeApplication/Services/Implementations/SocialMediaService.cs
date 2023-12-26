using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.SocialMedia;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;


namespace Resume.Application.Services.Implementations
{
    public class SocialMediaService : ISocialMediaService
    {
        #region Constructor
        private readonly AppDbContext _context;
        public SocialMediaService(AppDbContext context)
        {
            _context = context;
        }


        #endregion


        public async Task<SocialMedia> GetSocialMediaByID(long id)
        {
            return await _context.SocialMedia.FirstOrDefaultAsync(x => x.ID == id);
        }


        public async Task<List<SocialMediaViewModel>> GetAllSocialMedias()
        {
            List<SocialMediaViewModel> socialMedias = await _context.SocialMedia
                .OrderBy(c => c.Order)
                .Select(s => new SocialMediaViewModel()
                {
                    Order = s.Order,
                    ID = s.ID,
                    Icon = s.Icon,
                    Link = s.Link
                })
                .ToListAsync();

            return socialMedias;
        }


        public async Task<CreateOrEditSocialMediaViewModel> FillCreateOrEditSocialMediaViewModel(long id)
        {
            //Create
            if (id == 0) return new CreateOrEditSocialMediaViewModel() { ID = 0 };

            SocialMedia socialMedia = await GetSocialMediaByID(id);
            if (socialMedia == null) return new CreateOrEditSocialMediaViewModel() { ID = 0 };

            //Edit
            return new CreateOrEditSocialMediaViewModel()
            {
                ID = id,
                Icon = socialMedia.Icon,
                Link = socialMedia.Link,
                Order = socialMedia.Order
            };
        }


        public async Task<bool> CreateOrEditSocialMedia(CreateOrEditSocialMediaViewModel socialMedia)
        {
            //Create
            if(socialMedia.ID == 0)
            {
                SocialMedia newSocialMedia = new SocialMedia()
                {
                    Icon = socialMedia.Icon,
                    Link = socialMedia.Link,
                    Order = socialMedia.Order
                };

                await _context.SocialMedia.AddAsync(newSocialMedia);
                await _context.SaveChangesAsync();
                return true;
            }

            SocialMedia currentSocialMedia = await GetSocialMediaByID(socialMedia.ID);
            if (currentSocialMedia.ID == 0) return false;

            //Edit
            currentSocialMedia.Icon = socialMedia.Icon;
            currentSocialMedia.Link = socialMedia.Link;
            currentSocialMedia.Order = socialMedia.Order;

            _context.SocialMedia.Update(currentSocialMedia);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSocialMedia(long id)
        {
            SocialMedia socialMedia = await GetSocialMediaByID(id);
            if (socialMedia.ID == 0) return false;

            _context.SocialMedia.Remove(socialMedia);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
