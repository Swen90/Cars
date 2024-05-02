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

        public List<Guid> CreateByCarId(CarEngineWriteDto carEngineDto)
        {
            List<Guid> list = new List<Guid>();
            ///Comment: Локально заполнить для добавления CarEngineWriteDto
            foreach (var engineWriteDto in carEngineDto.EngineId) /// null
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

        private bool isExistsEngineById(Guid id)
        {
            Engine? engine = _db.Engines.Where(e => e.Id == id).FirstOrDefault();
            if (engine == null) 
                return false;

            return true;
        }
    }
}