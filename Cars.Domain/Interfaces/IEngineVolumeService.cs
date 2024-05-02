using Cars.Domain.Models;

namespace Cars.Domain.Interfaces
{
    public interface IEngineVolumeService
    {
        public List<EngineVolumeDto> GetAll();

        public EngineVolumeDto? GetById(int id);
    }
}
