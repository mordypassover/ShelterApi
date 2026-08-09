using EmergencyShelterReadinessSystemAPI.DTOs;

namespace EmergencyShelterReadinessSystemAPI.Repositorys;

public interface IAreaRepository
{
    Task<IEnumerable<AreaStatisticsDto>> GetAreaStatisticsAsynk();
}
