using BlackoutMonitorAPI.Data;
using BlackoutMonitorAPI.Dto;
using BlackoutMonitorAPI.Exceptions;
using BlackoutMonitorAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlackoutMonitorAPI.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/v1/alerts")]
    public class AlertsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AlertsController> _logger;

        public AlertsController(ApplicationDbContext context, ILogger<AlertsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlert([FromBody] AlertCreateDto dto)
        {
            var region = await _context.Regions.FindAsync(dto.RegionId);
            if (region is null)
                throw new RegionNotFoundException(dto.RegionId);

            if (dto.DeviceId.HasValue)
            {
                var deviceExists = await _context.Devices.AnyAsync(d => d.Id == dto.DeviceId);
                if (!deviceExists)
                    return NotFound(new { error = "Dispositivo informado não existe." });
            }

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                throw new UserNotAuthenticatedException();

            int userId = int.Parse(userIdClaim.Value);

            var alert = new Alert
            {
                Message = dto.Message,
                RegionId = dto.RegionId,
                DeviceId = dto.DeviceId,
                UserId = userId
            };

            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Alerta registrado por UserId={UserId} na Região {RegionId}", userId, dto.RegionId);

            return Ok(alert);
        }



        [HttpGet("report")]
        public async Task<IActionResult> GetReport()
        {
            var alerts = await _context.Alerts
                .Include(a => a.Region)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();

            return Ok(alerts);
        }
    }
}
