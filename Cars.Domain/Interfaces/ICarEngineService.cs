using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface ICarEngineService
    {
        public List<EngineReadDto>? GetAllByCarId(Guid carId);

        public List<Guid> CreateByCarId(CarEngineWriteDto carEngineDto);

        public bool DeleteById(CarEngineWriteDto carEngineDtos);
    }
}
