using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;


namespace Resume.Application.Services.Implementations
{
    public class ExperienceService : IExperienceService
    {
        #region Constructor
        private readonly AppDbContext _context;
        public ExperienceService(AppDbContext context)
        {
            _context = context;
        }

        #endregion


        public async Task<Experience> GetExperienceByID(long id)
        {
            return await _context.Experiences.FirstOrDefaultAsync(e => e.ID == id);
        }
        public async Task<List<ExperienceViewModel>> GetAllExperiences()
        {
            List<ExperienceViewModel> experienceList = await _context.Experiences
               .OrderBy(c => c.Order)
               .Select(c => new ExperienceViewModel()
               {
                   ID = c.ID,
                   EndDate = c.EndDate,
                   StartDate = c.StartDate,
                   Title = c.Title,
                   Description = c.Description,
                   Order = c.Order
               })
               .ToListAsync();

            return experienceList;
        }

        public async Task<CreateOrEditExperienceViewModel> FillCreateOrEditExperienceViewModel(long id)
        {
            //Create
            if (id == 0) return new CreateOrEditExperienceViewModel() { ID = 0 };

            Experience experience = await GetExperienceByID(id);
            if (experience == null) return new CreateOrEditExperienceViewModel() { ID = 0 };

            //Edit
            return new CreateOrEditExperienceViewModel()
            {
                Title = experience.Title,
                ID = experience.ID,
                Description = experience.Description,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,
                Order = experience.Order
            };
        }

        public async Task<bool> CreateOrEditExperience(CreateOrEditExperienceViewModel experience)
        {
            //Create
            if (experience.ID == 0)
            {
                Experience newExperience = new Experience()
                {
                    Description = experience.Description,
                    Order = experience.Order,
                    EndDate = experience.EndDate,
                    StartDate = experience.StartDate,
                    Title = experience.Title
                };

                await _context.Experiences.AddAsync(newExperience);
                await _context.SaveChangesAsync();

                return true;
            }

            Experience currentExperience = await GetExperienceByID(experience.ID);
            if (currentExperience == null) return false;

            currentExperience.StartDate = experience.StartDate;
            currentExperience.EndDate = experience.EndDate;
            currentExperience.Description = experience.Description;
            currentExperience.Order = experience.Order;
            currentExperience.Title = experience.Title;

            _context.Experiences.Update(currentExperience);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteExperience(long id)
        {
            Experience experience = await GetExperienceByID(id);

            if (experience == null) return false;

            _context?.Experiences.Remove(experience);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
