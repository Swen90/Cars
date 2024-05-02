using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;

namespace Cars.Infrastructure.Services
{
    public class WeakPointService : IWeakPointService
    {
        CarsDbContext _db;

        public WeakPointService(CarsDbContext db)
        {
            _db = db;
        }

        public List<WeakPointDto> GetAll()
        {
            List<WeakPoint> weakPoints = _db.WeakPoints.ToList();
            if (weakPoints == null)
                return new List<WeakPointDto>();

            return weakPoints.ToWeakPointDtos();
        }

        public WeakPointDto? GetById(int id)
        {
            WeakPoint? weakPoint = _db.WeakPoints.Where(w => w.Id == id).FirstOrDefault();
            if (weakPoint == null)
                return null;

            return weakPoint.ToWeakPointDto();
        }
    }
}
