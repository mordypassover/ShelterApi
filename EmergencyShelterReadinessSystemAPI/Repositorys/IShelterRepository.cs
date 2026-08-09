using EmergencyShelterReadinessSystemAPI.DTOs;

namespace EmergencyShelterReadinessSystemAPI.Repositorys;

public interface IShelterRepository
{
   Task<IEnumerable<ShelterWithAreaDto>> GetShelterWithAreaAsynk();
    Task<IEnumerable<ShelterSearchResultDto>> GetFilteredShelters(
         string? city,
         int? minCapacity,
         bool? isAccessible,
         bool? isPublic);

}
