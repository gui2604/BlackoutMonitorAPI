using BlackoutMonitorAPI.Data;
using BlackoutMonitorAPI.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackoutMonitorAPI.Controller
{
    [ApiController]
    [Route("api/healthcheck")]
    public class HealthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HealthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult BasicCheck()
        {
            return Ok(new
            {
                status = "Healthy",
                timestamp = DateTime.UtcNow
            });
        }

        [HttpGet("full")]
        [Authorize]
        public async Task<IActionResult> FullCheck()
        {
            var canConnect = await _context.Database.CanConnectAsync();
            if (!canConnect)
                throw new DatabaseUnavailableException("Não foi possível conectar ao banco de dados.");

            return Ok(new
            {
                status = "Healthy",
                database = "Connected",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
