using Cars.CarsDb.Models;
using Cars.Domain.Models;

namespace Cars.Infrastructure.Mappings
{
    public static class EngineMappings
    {
        public static List<EngineReadDto> ToListEngineDtos(this List<Engine> engines)
            => engines.Select(e => e.ToEngineDto()).ToList();

        public static EngineReadDto ToEngineDto(this Engine engine)
        {
            EngineReadDto engineDto = new EngineReadDto()
            {
                Id = engine.Id,
                EngineCategory = engine.EngineCategory != null ? engine.EngineCategory.ToEngineCategory() : null,
                EngineVolume = engine.EngineVolume != null ? engine.EngineVolume.ToEngineVolumeDto() : null,
            };
            return engineDto;
        }
    }
}
