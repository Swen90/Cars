﻿using Cars.CarsDb.Models;
using Cars.Domain.Models;

namespace Cars.Infrastructure.Mappings
{
    public static class CarCategoryMappings
    {
        public static List<CarCategoryDto> ToCarCategoryDtos(this List<CarCategory> listCars)
            => listCars.Select(c => c.ToCarCategoryDto()).ToList(); /// вместо foreach, упростить код в сервисе

        public static CarCategoryDto ToCarCategoryDto(this CarCategory carCategory) 
        {
            CarCategoryDto carCategoryDto = new CarCategoryDto
            {
                Id = carCategory.Id,
                Name = carCategory.Name,
            };
            return carCategoryDto;
        }
    }
}
