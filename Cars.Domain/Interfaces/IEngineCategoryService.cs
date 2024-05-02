using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface IEngineCategoryService
    {
        public List<EngineCategoryDto> GetAll();

        public EngineCategoryDto? GetById(int id);
    }
}
