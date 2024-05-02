using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface IWeakPointService
    {
        public List<WeakPointDto> GetAll();

        public WeakPointDto? GetById(int id);
    }
}
