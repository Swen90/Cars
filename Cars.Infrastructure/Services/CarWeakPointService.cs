using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Cars.Infrastructure.Services
{
    public class CarWeakPointService : ICarWeakPointService
    {
        CarsDbContext _db;

        public CarWeakPointService(CarsDbContext db)
        {
            _db = db;
        }

        private CarWeakPoint? GetById(int id)
        {
            CarWeakPoint? carWeakPoint = _db.CarWeakPoints.
                Where(c => c.Id == id).
                Include(c => c.Car).
                Include(c => c.WeakPoint).
                FirstOrDefault();

            if (carWeakPoint == null)
                return null;

            return carWeakPoint;
        }

        public List<WeakPointDto> GetAllDtosByCarId(Guid carId)
        {
            List<WeakPoint>? weakPoints = _db.CarWeakPoints.
                Where(s => s.CarId == carId && s.WeakPointId != null). ///Comment: Этим выражением устанавливаем логику
                Include(s => s.Car!).
                ThenInclude(c => c.CarCategory).
                Include(s => s.WeakPoint).
                Select(s => s.WeakPoint!). ///Comment: Знак ! для warning Visual Studio
                ToList();

            if (weakPoints == null)
                return new List<WeakPointDto>();

            return weakPoints.ToWeakPointDtos();
        }

        public CarWeakPointReadDto? GetDtoById(int id)
        {
            var carWeakPoint = GetById(id);
            if (carWeakPoint == null)
                return null;

            return carWeakPoint.ToCarWeakPointDto();
        }

        public int CreateById(CarWeakPointWriteDto carWeakPointDto) ///Comment: Вернуть id новой записи вместо CarStrongPointDto
        {
            CarWeakPoint carWeakPoint = new CarWeakPoint()
            {
                CarId = carWeakPointDto.CarId,
                WeakPointId = carWeakPointDto.WeakPointId,
            };
            _db.CarWeakPoints.Add(carWeakPoint);
            _db.SaveChanges();
            return carWeakPoint.Id;
        }

        public int? DeleteById(int id)
        {
            CarWeakPoint? deletedEntry = GetById(id);
            if (deletedEntry == null)
                return null;

            _db.CarWeakPoints.Remove(deletedEntry);
            _db.SaveChanges();
            return deletedEntry.Id;
        }

        public bool EntryExisted(int id)
        {
            CarWeakPoint? carWeakPoint = GetById(id);
            if (carWeakPoint == null)
                return false;

            return true;
        }
    }
}
