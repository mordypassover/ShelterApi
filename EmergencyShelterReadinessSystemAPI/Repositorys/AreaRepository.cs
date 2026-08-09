using EmergencyShelterReadinessSystemAPI.Data;
using EmergencyShelterReadinessSystemAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmergencyShelterReadinessSystemAPI.Repositorys;

public class AreaRepository:IAreaRepository
{
    MyDbContext _dbContext;
    public AreaRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<AreaStatisticsDto>> GetAreaStatisticsAsynk()
    {
        var data = _dbContext.Areas
            .Select(a => new AreaStatisticsDto
            {
                City = a.City,
                Neighborhood = a.Neighborhood,
                ShelterCount = a.Shelters.Count,
                TotalCapacity = a.Shelters.Sum(s => s.Capacity)
            });
        return await data.ToListAsync();
    }
   
}
