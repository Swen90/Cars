﻿
namespace Cars.Domain.Models
{
    public class CarDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public CarCategoryDto? CarCategory { get; set; }
    }
}
