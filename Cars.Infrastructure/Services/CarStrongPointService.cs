using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Cars.Infrastructure.Services
{
    public class CarStrongPointService : ICarStrongPointService
    {
        readonly CarsDbContext _db;

        public CarStrongPointService(CarsDbContext db) 
        {
            _db = db;
        }

        private CarStrongPoint? GetById(int id)
        {
            CarStrongPoint? carStrongPoint = _db.CarStrongPoints.
                Where(c => c.Id == id).
                Include(c => c.Car!).
                ThenInclude(c => c.CarCategory).
                Include(c => c.StrongPoint).
                FirstOrDefault();

            if (carStrongPoint == null)
                return null;

            return carStrongPoint;
        }

        public List<StrongPointDto> GetAllDtosByCarId(Guid carId)
        {
            List<StrongPoint>? strongPoints = _db.CarStrongPoints.
                Where(s => s.CarId == carId && s.StrongPointId != null). ///Comment: Этим выражением устанавливаем логику
                Include(s => s.Car).
                Include(s => s.StrongPoint).
                Select(s => s.StrongPoint!). ///Comment: Знак ! для warning Visual Studio
                ToList();

            if(strongPoints == null)
                return new List<StrongPointDto>();

            return strongPoints.ToStrongPointDtos();
        }
        
        ///Comment: Написать метод GetCarStrongPointByCarId по новой созданной записи CarStrongPoint
        public CarStrongPointReadDto? GetDtoById(int id)
        {
            var carStrongPoint = GetById(id);
            if (carStrongPoint == null)
                return null;

            return carStrongPoint.ToCarStrongPointDto();
        }

        public int CreateById(CarStrongPointWriteDto carStrongPointDto)
        {
            CarStrongPoint carStrongPoint = new CarStrongPoint()
            { 
                CarId = carStrongPointDto.CarId,
                StrongPointId = carStrongPointDto.StrongPointId,
            };
            _db.CarStrongPoints.Add(carStrongPoint);
            _db.SaveChanges();
            return carStrongPoint.Id;
        }

        public int? DeleteById(int id)
        {
            CarStrongPoint? deletedEntry = GetById(id);
            if (deletedEntry == null)
                return null;

            _db.CarStrongPoints.Remove(deletedEntry);
            _db.SaveChanges();
            return deletedEntry.Id;
        }

        public bool EntryExisted(int id)
        {
            CarStrongPoint? carStrongPoint = GetById(id);
            if(carStrongPoint == null)
                return false;

            return true;
        }
    }
}
