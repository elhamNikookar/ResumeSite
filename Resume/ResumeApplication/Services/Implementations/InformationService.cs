using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;


namespace Resume.Application.Services.Implementations
{
    public class InformationService : IInformationService
    {

        #region Constructor
        private readonly AppDbContext _context;
        public InformationService(AppDbContext context)
        {
            _context = context;
        }

       
        #endregion

        public async Task<InformationViewModel> GetInformation()
        {
            InformationViewModel information = await _context.Information
                .Select(x => new InformationViewModel()
                {
                    ID = x.ID,
                    Avatar = x.Avatar,
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    Job = x.Job,
                    Phone = x.Phone,
                    ResumeFile = x.ResumeFile,
                    Name = x.Name ,
                    MapSrc = x.MapSrc
                })
                .FirstOrDefaultAsync();

            if(information == null)
                return new InformationViewModel();

            return information; 

        }

        public async Task<Information> GetInformationModel()
        {
            return await _context.Information.FirstOrDefaultAsync();
        }

        public async Task<CreateOrEditInformationViewModel> FillCreateOrEditInformationViewModel()
        {
            Information information = await GetInformationModel();
            if (information == null) return new CreateOrEditInformationViewModel() { ID = 0 };

            return new CreateOrEditInformationViewModel()
            {
                ID = information.ID,
                Name = information.Name,
                Address = information.Address,
                Avatar = information.Avatar,
                DateOfBirth = information.DateOfBirth,
                Email = information.Email,
                Job = information.Job,
                Phone = information.Phone,
                MapSrc = information.MapSrc,
                ResumeFile = information.ResumeFile
            };
        }


        public async Task<bool> CreateOrEditInformation(CreateOrEditInformationViewModel information)
        {
            //Create
            if(information.ID == 0)
            {
                Information newInformation = new Information()
                {
                    Name = information.Name,
                    Address = information.Address,
                    Avatar = information.Avatar,
                    DateOfBirth = information.DateOfBirth,
                    Email = information.Email,
                    Job = information.Job,
                    Phone = information.Phone,
                    MapSrc = information.MapSrc,
                    ResumeFile = information.ResumeFile
                };

                await _context.Information.AddAsync(newInformation);
                await _context.SaveChangesAsync();
                return true;
            }
            Information currentInformation = await GetInformationModel();

            //Edit
            currentInformation.Name = information.Name;
            currentInformation.Address = information.Address;
            currentInformation.Avatar = information.Avatar;
            currentInformation.Phone = information.Phone;
            currentInformation.MapSrc = information.MapSrc;
            currentInformation.Email = information.Email;
            currentInformation.Job = information.Job;
            currentInformation.ResumeFile = information.ResumeFile;
            currentInformation.DateOfBirth = information.DateOfBirth;

            _context.Information.Update(currentInformation);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
