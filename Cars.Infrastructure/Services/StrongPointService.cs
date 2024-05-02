using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;

namespace Cars.Infrastructure.Services
{
    public class StrongPointService : IStrongPointService
    {
        CarsDbContext _db;
        public StrongPointService(CarsDbContext db)
        {
            _db = db;
        }

        public List<StrongPointDto> GetAll()
        {
            List<StrongPoint> strongPoints = _db.StrongPoints.ToList();
            if(strongPoints == null)
                return new List<StrongPointDto>();

            return strongPoints.ToStrongPointDtos();
        }
        public StrongPointDto? GetById(int id)
        {
            StrongPoint? strongPoint = _db.StrongPoints.Where(x => x.Id == id).FirstOrDefault();
            if (strongPoint == null)
                return null;

            return strongPoint.ToStrongPointDto();
        }
    }
}
