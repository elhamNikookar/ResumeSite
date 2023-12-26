using Resume.Domain.ViewModels.Education;
using Resume.Domain.ViewModels.Experience;
using Resume.Domain.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Page
{
    public class ResumePageViewModel
    {
        public List<EducationViewModel> EducationsList { get; set; }
        public List<ExperienceViewModel> ExperiencesList { get; set; }
        public List<SkillViewModel> SkillsList { get; set; }
    }
}
