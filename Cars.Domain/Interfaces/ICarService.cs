using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface ICarService
    {
        public List<CarDto> GetAll();
    }
}
