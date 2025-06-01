using System.ComponentModel.DataAnnotations;

namespace BlackoutMonitorAPI.Dto
{
    public class DeviceCreateDto
    {
        [Required]
        public required string Identifier { get; set; }

        [Required]
        public required int RegionId { get; set; }
    }
}
