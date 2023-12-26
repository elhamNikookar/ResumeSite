using Resume.Domain.Models;
using Resume.Domain.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface ISkillService
    {

        Task<Skill> GetSkillByID(long id);
        Task<List<SkillViewModel>> GetAllSkills();
        Task<bool> CreateOrEditSkill(CreateOrEditSkillViewModel skill);
        Task<bool> DeleteSkill(long id);
        Task<CreateOrEditSkillViewModel> FillCreateOrEditSkillViewModel(long id);
    }
}
