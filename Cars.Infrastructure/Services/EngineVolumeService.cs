using Cars.CarsDb.Context;
using Cars.CarsDb.Models;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infrastructure.Mappings;

namespace Cars.Infrastructure.Services
{
    public class EngineVolumeService : IEngineVolumeService
    {
        CarsDbContext _db;

        public EngineVolumeService(CarsDbContext db) 
        {
            _db = db;
        }

        public List<EngineVolumeDto> GetAll()
        {
            List<EngineVolume> engineVolumes = _db.EngineVolumes.ToList();
            if(engineVolumes == null)
                return new List<EngineVolumeDto>();

            return engineVolumes.ToEngineVolumeDtos();
        }

        public EngineVolumeDto? GetById(int id)
        {
            EngineVolume? engineVolume = _db.EngineVolumes.Where(e => e.Id == id).FirstOrDefault();
            if (engineVolume == null)
                return null;

            return engineVolume.ToEngineVolumeDto();
        }
    }
}
