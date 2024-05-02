using Cars.CarsDb.Models;
using Cars.Domain.Models;

namespace Cars.Infrastructure.Mappings
{
    public static class CarStrongPointMapping
    {
        public static CarStrongPointReadDto ToCarStrongPointReadDto(this CarStrongPoint carStrongPoint)
        {
            CarStrongPointReadDto carStrongPointDto = new CarStrongPointReadDto()
            {
                Id = carStrongPoint.Id,

                Car = carStrongPoint.Car != null ? carStrongPoint.Car.ToCarDto() : null,

                StrongPoint = carStrongPoint.StrongPoint != null ? carStrongPoint.StrongPoint.ToStrongPointDto() : null,
            };
            return carStrongPointDto;
        }
    }
}
