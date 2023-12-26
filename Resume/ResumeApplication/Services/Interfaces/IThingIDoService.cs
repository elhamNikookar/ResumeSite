using Resume.Domain.Models;
using Resume.Domain.ViewModels;
using Resume.Domain.ViewModels.ThingIDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IThingIDoService
    {

        Task<ThingIDo> GetThingIDoByID(long id);
        Task<List<ThingIDoListViewModel>> GetAllThingIDoForIndex();
        Task<bool> CreateOrEditThingIDo(CreateOrEditThingIDoViewModel thingIDo);
        Task<bool> DeleteThingIDo(long id );
        Task<CreateOrEditThingIDoViewModel> FillCreateOrEditThingIDoViewModel(long id);

    }
}
