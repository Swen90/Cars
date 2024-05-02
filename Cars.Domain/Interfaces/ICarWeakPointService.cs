using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface ICarWeakPointService
    {
        public List<WeakPointDto> GetAllDtosByCarId(Guid carId);

        public CarWeakPointReadDto? GetDtoById(int id);

        public int CreateById(CarWeakPointWriteDto carWeakPointDto);

        public int? DeleteById(int id);

        public bool EntryExisted(int id);
    }
}
