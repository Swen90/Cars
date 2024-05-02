
namespace Cars.Domain.Models
{
    public class CarEngineWriteDto
    {
        public Guid CarId { get; set; }

        public List<Guid> EngineId { get; set; } = new List<Guid>();
    }
}