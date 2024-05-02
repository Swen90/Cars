using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface IStrongPointService
    {
        public List<StrongPointDto> GetAll();

        public StrongPointDto? GetById(int id);
    }
}
