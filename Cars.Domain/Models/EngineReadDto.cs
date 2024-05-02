
namespace Cars.Domain.Models
{
    public class EngineReadDto
    {
        public Guid Id { get; set; }

        public EngineCategoryDto? EngineCategory { get; set; }

        public EngineVolumeDto? EngineVolume { get; set; }
    }
}
