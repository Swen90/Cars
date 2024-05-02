using Cars.CarsDb.Models;
using Cars.Domain.Models;

namespace Cars.Infrastructure.Mappings
{
    public static class CarWeakPointMappings
    {
        public static CarWeakPointReadDto ToCarWeakPointDto(this CarWeakPoint carWeakPoint)
        {
            CarWeakPointReadDto carWeakPointDto = new CarWeakPointReadDto()
            {
                Id = carWeakPoint.Id,

                Car = carWeakPoint.Car != null ? carWeakPoint.Car.ToCarDto() : null,

                WeakPoint = carWeakPoint.WeakPoint != null ? carWeakPoint.WeakPoint.ToWeakPointDto() : null,
            };
            return carWeakPointDto;
        }
    }
}
