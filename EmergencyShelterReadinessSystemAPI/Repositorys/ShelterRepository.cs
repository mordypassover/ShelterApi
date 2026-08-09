using EmergencyShelterReadinessSystemAPI.Data;
using EmergencyShelterReadinessSystemAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmergencyShelterReadinessSystemAPI.Repositorys;

public class ShelterRepository:IShelterRepository
{
    MyDbContext _dbContext;

    public ShelterRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<ShelterWithAreaDto>> GetShelterWithAreaAsynk()
    {
        var data =  _dbContext.Shelters
        .Select(s => new ShelterWithAreaDto
        {
            ShelterId = s.Id,
            ShelterName = s.Name,
            Capacity = s.Capacity,
            City = s.Area.City,
            Neighborhood = s.Area.Neighborhood
        });

        return await data.ToListAsync();
    }
    public async Task<IEnumerable<ShelterSearchResultDto>> GetFilteredShelters(
        string? city,
        int? minCapacity,
        bool? isAccessible,
        bool? isPublic
        )
    {
        var query = _dbContext.Shelters
        .Include(s => s.Area)
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(s => s.Area.City == city);
        }

        if (minCapacity.HasValue)
        {
            query = query.Where(s => s.Capacity >= minCapacity.Value);
        }

        if (isAccessible.HasValue)
        {
            query = query.Where(s => s.IsAccessible == isAccessible.Value);
        }

        if (isPublic.HasValue)
        {
            query = query.Where(s => s.IsPublic == isPublic.Value);
        }

        return await query
            .Select(s => new ShelterSearchResultDto
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                Capacity = s.Capacity,
                IsAccessible = s.IsAccessible,
                City = s.Area.City
            })
            .ToListAsync();
    }
    


}

