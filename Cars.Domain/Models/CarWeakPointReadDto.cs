
namespace Cars.Domain.Models
{
    public class CarWeakPointReadDto
    {
        public int Id { get; set; }

        public CarDto? Car { get; set; } = null!; 

        public WeakPointDto? WeakPoint { get; set; } = null!;
    }
}


