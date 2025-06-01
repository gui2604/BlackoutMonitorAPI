using System.ComponentModel.DataAnnotations;

namespace BlackoutMonitorAPI.Dto
{
    public class AlertCreateDto
    {
        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public int RegionId { get; set; }
        public int? DeviceId { get; set; } 
    }
}
