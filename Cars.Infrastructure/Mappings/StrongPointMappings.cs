using Cars.CarsDb.Models;
using Cars.Domain.Models;

namespace Cars.Infrastructure.Mappings
{
    public static class StrongPointMappings
    {
        public static List<StrongPointDto> ToStrongPointDtos(this List<StrongPoint> strongPoints) 
            => strongPoints.Select(s => s.ToStrongPointDto()).ToList();

        public static StrongPointDto ToStrongPointDto(this StrongPoint strongPoint)
        {
            StrongPointDto strongPointDto = new StrongPointDto()
            {
                Id = strongPoint.Id,
                Name = strongPoint.Name,
            };
            return strongPointDto;
        }
    }
}
