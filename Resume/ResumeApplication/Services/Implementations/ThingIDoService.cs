using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.ThingIDo;
using Resume.Infra.Data.Context;
using Resume.Application.Services.Interfaces;


namespace Resume.Application.Services.Implementations
{
    public class ThingIDoService : IThingIDoService
    {

        #region Constructor
        private readonly AppDbContext _context;
        public ThingIDoService(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        public async Task<ThingIDo> GetThingIDoByID(long id)
        {
            return await _context.ThingIDos.FirstOrDefaultAsync(t => t.ID == id);

        }

        public async Task<List<ThingIDoListViewModel>> GetAllThingIDoForIndex()
        {
            List<ThingIDoListViewModel> thingIDo = await _context.ThingIDos
                .OrderBy(c => c.Order)
                .Select(t => new ThingIDoListViewModel()
                {
                    ID = t.ID,
                    ColumnLg = t.ColumnLg,
                    Description = t.Description,
                    Order = t.Order,
                    Icon = t.Icon,
                    Title = t.Title
                })
                .ToListAsync();
            
            return thingIDo;
        }

       public async Task<bool> CreateOrEditThingIDo(CreateOrEditThingIDoViewModel thingIDo)
        {
            if(thingIDo.ID == 0)
            {
                //create
                ThingIDo newThingIDo = new ThingIDo()
                {
                    Title = thingIDo.Title,
                    Order = thingIDo.Order,
                    Icon = thingIDo.Icon,
                    Description = thingIDo.Description,
                    ColumnLg = thingIDo.ColumnLg
                };

                await _context.ThingIDos.AddAsync(newThingIDo);
                await _context.SaveChangesAsync();
                return true;

            }

            //Edit
            ThingIDo currentThingIDo = await GetThingIDoByID(thingIDo.ID);
           
            if(currentThingIDo == null) return false;

            currentThingIDo.Title = thingIDo.Title;
            currentThingIDo.Description = thingIDo.Description;
            currentThingIDo.Order = thingIDo.Order;
            currentThingIDo.Icon = thingIDo.Icon;
            currentThingIDo.ColumnLg = thingIDo.ColumnLg;

            _context.ThingIDos.Update(currentThingIDo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CreateOrEditThingIDoViewModel> FillCreateOrEditThingIDoViewModel(long id)
        {
            if (id == 0) return new CreateOrEditThingIDoViewModel() { ID = 0 };

            ThingIDo thingIDo = await GetThingIDoByID(id);

            if (thingIDo == null) return new CreateOrEditThingIDoViewModel() { ID = 0 };

            return new CreateOrEditThingIDoViewModel()
            {
                ID = thingIDo.ID,
                Title = thingIDo.Title,
                Icon = thingIDo.Icon,
                ColumnLg = thingIDo.ColumnLg,
                Description = thingIDo.Description,
                Order = thingIDo.Order
            };

        }

        public async Task<bool> DeleteThingIDo(long id)
        {
            ThingIDo thingIDo = await GetThingIDoByID(id);
            
            if(thingIDo == null) return false;

            _context.ThingIDos.Remove(thingIDo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
