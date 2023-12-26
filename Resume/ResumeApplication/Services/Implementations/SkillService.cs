using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Skill;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {

        #region Constructor
        private readonly AppDbContext _context;
        public SkillService(AppDbContext context)
        {
            _context = context;
        }

      
        #endregion


        public async Task<Skill> GetSkillByID(long id)
        {
            return await _context.Skills.FirstOrDefaultAsync(s => s.ID == id); 
        }

        public async Task<List<SkillViewModel>> GetAllSkills()
        {
            List<SkillViewModel> skills = await _context.Skills
                .OrderBy(c => c.Order)
                .Select(c => new SkillViewModel()
                {
                    Order = c.Order,
                    Title = c.Title,
                    Percent = c.Percent,
                    ID = c.ID
                })
                .ToListAsync();
          
            return skills;
        }

        public async Task<bool> CreateOrEditSkill(CreateOrEditSkillViewModel skill)
        {
            //Create
            if (skill.ID == 0)
            {
                Skill newSkill = new Skill()
                {
                    Title = skill.Title,
                    Order = skill.Order,
                    Percent = skill.Percent
                };

                await _context.Skills.AddAsync(newSkill);
                await _context.SaveChangesAsync();

                return true;
            }

            Skill currentSkill = await GetSkillByID(skill.ID);

            if (currentSkill == null) return false;

            //Edit
            currentSkill.Order = skill.Order;
            currentSkill.Title = skill.Title;
            currentSkill.Percent = skill.Percent;

            _context.Skills.Update(currentSkill);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSkill(long id)
        {
            Skill skill = await GetSkillByID(id);

            if (skill == null) return false;

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CreateOrEditSkillViewModel> FillCreateOrEditSkillViewModel(long id)
        {
            //Create
            if (id == 0) return new CreateOrEditSkillViewModel() { ID = 0 };

            Skill skill = await GetSkillByID(id);

            if(skill == null) return new CreateOrEditSkillViewModel() { ID = 0};

            return new CreateOrEditSkillViewModel()
            {
                ID = skill.ID,
                Order = skill.Order,
                Percent = skill.Percent,
                Title = skill.Title
            };
        }

    }
}
