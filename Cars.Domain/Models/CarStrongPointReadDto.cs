
namespace Cars.Domain.Models
{
    public class CarStrongPointReadDto
    {
        public int Id { get; set; }

        public CarDto? Car { get; set; } = null!; ///Comment: Выражение чтобы указать что мы знаем про наличие null, но мы берем ответственность на себя и убираем warnings

        public StrongPointDto? StrongPoint { get; set; } = null!;
    }
}
