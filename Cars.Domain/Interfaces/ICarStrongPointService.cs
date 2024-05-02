using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface ICarStrongPointService
    {
        public List<StrongPointDto> GetAllDtosByCarId(Guid carId);

        public int CreateById(CarStrongPointWriteDto carStrongPointDto);
        
        public CarStrongPointReadDto? GetDtoById(int id);

        public int? DeleteById(int id);

        public bool EntryExisted(int id);
    }
}
