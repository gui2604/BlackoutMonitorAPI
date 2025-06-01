using BlackoutMonitorAPI.Data;
using BlackoutMonitorAPI.Dto;
using BlackoutMonitorAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlackoutMonitorAPI.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/v1/devices")]
    public class DevicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DevicesController> _logger;

        public DevicesController(ApplicationDbContext context, ILogger<DevicesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] DeviceCreateDto dto)
        {
            var region = await _context.Regions.FindAsync(dto.RegionId);
            if (region == null)
                return NotFound(new { error = "Região não encontrada" });

            var device = new Device
            {
                Identifier = dto.Identifier,
                RegionId = dto.RegionId
            };

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Dispositivo '{Identifier}' cadastrado na região {RegionId}", device.Identifier, device.RegionId);

            var response = new DeviceResponseDto
            {
                Id = device.Id,
                Identifier = device.Identifier,
                RegionId = device.RegionId
            };

            return Ok(response);
        }

        [HttpGet("by-region/{regionId}")]
        public async Task<IActionResult> GetDevicesByRegion(int regionId)
        {
            var regionExists = await _context.Regions.AnyAsync(r => r.Id == regionId);
            if (!regionExists)
                return NotFound(new { error = "Região não encontrada" });

            var devices = await _context.Devices
                .Where(d => d.RegionId == regionId)
                .Select(d => new DeviceResponseDto
                {
                    Id = d.Id,
                    Identifier = d.Identifier,
                    RegionId = d.RegionId
                })
                .ToListAsync();

            return Ok(devices);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _context.Devices
                .Select(d => new DeviceResponseDto
                {
                    Id = d.Id,
                    Identifier = d.Identifier,
                    RegionId = d.RegionId
                })
                .ToListAsync();

            return Ok(devices);
        }

        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteDevice(int id)
{
    var device = await _context.Devices.FindAsync(id);
    if (device == null)
        return NotFound(new { error = "Dispositivo não encontrado" });

    _context.Devices.Remove(device);
    await _context.SaveChangesAsync();

    _logger.LogInformation("Dispositivo ID={Id} removido.", id);

    return NoContent(); // HTTP 204
}

    }
}
