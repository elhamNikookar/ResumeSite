using Microsoft.AspNetCore.Mvc;
using Resume.Domain.ViewModels.Page;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Controllers
{
    public class ResumeController : Controller
    {
        #region Constructor
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;
        private readonly ISkillService _skillService;

        public ResumeController(IEducationService educationService , IExperienceService experienceService , ISkillService skillService)
        {
            _educationService = educationService;
            _experienceService = experienceService;
            _skillService = skillService;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            ResumePageViewModel model = new ResumePageViewModel()
            {
                EducationsList = await _educationService.GetAllEducations(),
                ExperiencesList = await _experienceService.GetAllExperiences() ,
                SkillsList = await _skillService.GetAllSkills()
            };

            return View(model);
        }
    }
}
