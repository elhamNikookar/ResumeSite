using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;


namespace Resume.Application.Services.Implementations
{
    public class EducationService : IEducationService
    {
        #region Constructor
        private readonly AppDbContext _context;
        public EducationService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<Education> GetEducationByID(long id)
        {
            return await _context.Educations.FirstOrDefaultAsync(e => e.ID == id);  
        }

        public async Task<List<EducationViewModel>> GetAllEducations()
        {
            List<EducationViewModel> educationList = await _context.Educations
                .OrderBy(s => s.Order)
                .Select(c => new EducationViewModel()
                {
                    ID = c.ID,
                    EndDate = c.EndDate,
                    StartDate = c.StartDate,
                    Title = c.Title,
                    Description = c.Description,
                    Order = c.Order
                })
                .ToListAsync();

            return educationList;
        }

        public async Task<CreateOrEditEducationViewModel> FillCreateOrEditEducationViewModel(long id)
        {
            //create
            if(id == 0) return new CreateOrEditEducationViewModel() { ID = 0 };
            
            Education education = await _context.Educations.FirstOrDefaultAsync(c => c.ID == id);

            if (education == null) return new CreateOrEditEducationViewModel() { ID = 0 };

            return new CreateOrEditEducationViewModel()
            {
                ID = education.ID,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Title = education.Title,
                Order = education.Order,
                Description = education.Description
            };

        }

        public async Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education)
        {
            //create
            if(education.ID == 0)
            {
                Education newEducation = new Education()
                {
                    Description = education.Description,
                    EndDate = education.EndDate,
                    StartDate = education.StartDate,
                    Order = education.Order,
                    Title = education.Title
                };

                await _context.Educations.AddAsync(newEducation);
                await _context.SaveChangesAsync();
                return true;
            }

            //Edit
            Education currentEducation = await GetEducationByID(education.ID);
            
            if (currentEducation == null) return false;

            currentEducation.Title = education.Title;
            currentEducation.StartDate = education.StartDate;
            currentEducation.EndDate = education.EndDate;
            currentEducation.Description = education.Description;
            currentEducation.Order = education.Order;

            _context.Educations.Update(currentEducation);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteEducation(long id)
        {
            Education education = await GetEducationByID(id);

            if (education == null) return false;

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();

            return true;
  
        }
    }
}
