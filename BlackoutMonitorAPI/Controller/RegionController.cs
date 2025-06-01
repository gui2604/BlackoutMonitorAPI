using BlackoutMonitorAPI.Model;
using BlackoutMonitorAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackoutMonitorAPI.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/region")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult<Region>> GetByCep([FromQuery] string cep)
        {
            try
            {
                var region = await _regionService.GetOrCreateRegionByCepAsync(cep);
                return Ok(region);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
