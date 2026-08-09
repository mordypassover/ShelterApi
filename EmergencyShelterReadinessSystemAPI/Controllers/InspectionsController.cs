using EmergencyShelterReadinessSystemAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;
using EmergencyShelterReadinessSystemAPI.DTOs;

namespace EmergencyShelterReadinessSystemAPI.Controllers
{
    [Route("api/inspection/[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        IInspectionRepository _repository;
        public InspectionsController(IInspectionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ditaled/")]
        public async Task<ActionResult<IEnumerable<InspectionDetailedDto>>> GetInspectionAsynk()
        {
            return Ok(await _repository.GetInspectionDetailedAsynk());
        }

        [HttpGet("failed/")]
        public async Task<ActionResult<IEnumerable<FailedInspectionDto>>> FailedInspectionsAsynk()
        {
            return Ok(await _repository.FailedInspectionsAsynk());
        }

    }

}
