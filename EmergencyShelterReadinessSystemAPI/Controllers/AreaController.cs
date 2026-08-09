using EmergencyShelterReadinessSystemAPI.DTOs;
using EmergencyShelterReadinessSystemAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyShelterReadinessSystemAPI.Controllers;

[Route("api/area/[controller]")]
[ApiController]
public class AreaController : ControllerBase
{
    IAreaRepository _repository;
    public AreaController(IAreaRepository repository)
    {
        _repository = repository;
    }
    [HttpGet("Statistics/")]
    public async Task<ActionResult<IEnumerable<AreaStatisticsDto>>> GetAreaStatisticsAsynk()
    {
        return Ok(await _repository.GetAreaStatisticsAsynk());
    }
}
