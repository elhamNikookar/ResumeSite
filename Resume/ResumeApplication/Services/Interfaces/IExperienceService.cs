using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;


namespace Resume.Application.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<Experience> GetExperienceByID(long id);

        Task<List<ExperienceViewModel>> GetAllExperiences();

        Task<CreateOrEditExperienceViewModel> FillCreateOrEditExperienceViewModel(long id);

        Task<bool> CreateOrEditExperience(CreateOrEditExperienceViewModel experience);

        Task<bool> DeleteExperience(long id);
    }
}
