using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackoutMonitorAPI.Model
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Identifier { get; set; }

        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        public Region? Region { get; set; }
    }
}
