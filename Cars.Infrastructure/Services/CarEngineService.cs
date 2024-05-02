using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Cars.Infrastructure.Services
{
    public class CarEngineService : ICarEngineService
    {
        readonly CarsDbContext _db;

        public CarEngineService(CarsDbContext db)
        {
            _db = db;
        }

        public List<EngineReadDto> GetAllByCarId(Guid carId)
        {
            List<Engine>? listEngineDtos = _db.CarEngines.
                Where(c => c.CarId == carId).
                Include(c => c.Car!).
                ThenInclude(c => c.CarCategory).
                Include(e => e.Engine!).
                ThenInclude(c => c.EngineCategory).
                Include(e => e.Engine!).
                ThenInclude(c => c.EngineVolume). /// .orderby().skip()...
                Select(s => s.Engine!).AsNoTracking().ToList();

            if (listEngineDtos == null)
                return new List<EngineReadDto>();

            return listEngineDtos.ToListEngineDtos();
        }

        private CarEngine? GetById(int id)
        {
            CarEngine? engine = _db.CarEngines.Where(i => i.Id == id).FirstOrDefault();
            if (engine == null)
                return null;

            return engine;
        }

        public List<Guid> CreateByCarId(CarEngineWriteDto carEngineDto)
        {
            List<Guid> list = new List<Guid>();
            ///Comment: Локально заполнить для добавления CarEngineWriteDto
            foreach (Guid engineWriteDto in carEngineDto.EngineId) /// null
            {
                ///Comment: Получение Engine, проверить на существование в бд в записи
                bool result = isExistsEngineById(engineWriteDto);
                if (result == true)
                {
                    CarEngine carEngine = new CarEngine()
                    {
                        CarId = carEngineDto.CarId,
                        EngineId = engineWriteDto,
                    };
                    list.Add(engineWriteDto);
                    _db.CarEngines.Add(carEngine);
                    _db.SaveChanges();
                }
            }
            return list;
        }

        private List<CarEngine> GetByCarId(CarEngineWriteDto dtos)
        {
            List<CarEngine> carEngine = _db.CarEngines.Where(i => i.CarId == dtos.CarId).Include(c => c.Car).Include(r => r.Engine).ToList();
            if (carEngine == null)
                return new List<CarEngine>();

            return carEngine;
        }

        public bool DeleteById(CarEngineWriteDto carEngineDtos)
        {
            List<CarEngine> deletedEntries = GetByCarId(carEngineDtos);

            foreach (CarEngine carEngine in deletedEntries)
            {
                if(carEngine == null)
                    return false;

                _db.CarEngines.Remove(carEngine);
                _db.SaveChanges();
            }
            return true;
        }

        private bool isExistsEngineById(Guid id) ///Comment: сделать проверку на существование в БД связи и проверку на дубликаты
        {
            Engine? engine = _db.Engines.Where(e => e.Id == id).FirstOrDefault();
            if (engine == null)     
                return false;

            return true;
        }
    }
}