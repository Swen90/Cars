using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface ICarCategoryService
    {
        public List<CarCategoryDto> GetAll(); ///Comment: В интерфейсах, с листов лучше убирать знак ? и возвращать пустой экземпляр листа (если с БД возвращается null)

        public CarCategoryDto? GetById(int id);
    }
}
