using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;

namespace Cars.Infrastructure.Services
{
    public class CarCategoryService : ICarCategoryService
    {
        readonly CarsDbContext _db;

        public CarCategoryService(CarsDbContext db)
        {
            _db = db;
        }

        public List<CarCategoryDto> GetAll()
        {
            List<CarCategory> carCategories = _db.CarCategories.ToList();
            if (carCategories == null)
                return new List<CarCategoryDto>();
            
            return carCategories.ToCarCategoryDtos();
        }

        public CarCategoryDto? GetById(int id) 
        {
            CarCategory? carCategory = _db.CarCategories.Where(r => r.Id == id).FirstOrDefault();
            if (carCategory == null)
                return null;

            return carCategory.ToCarCategoryDto();
        }
    }
}
