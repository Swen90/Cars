using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;

namespace Cars.Infrastructure.Services
{
    public class EngineCategoryService : IEngineCategoryService
    {
        CarsDbContext _db;

        public EngineCategoryService(CarsDbContext db)
        {
            _db = db;
        }

        public List<EngineCategoryDto> GetAll()
        {
            List<EngineCategory> engineCategories = _db.EngineCategories.ToList();
            if (engineCategories == null)
                return new List<EngineCategoryDto>();

            return engineCategories.ToEngineCaegoryDtos();
        }

        public EngineCategoryDto? GetById(int id)
        {
            EngineCategory? engineCategory = _db.EngineCategories.Where(e => e.Id == id).FirstOrDefault();
            if (engineCategory == null)
                return null;

            return engineCategory.ToEngineCategory();
        }
    }
}
