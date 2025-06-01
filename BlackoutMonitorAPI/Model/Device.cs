using BlackoutMonitorAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackoutMonitorAPI.Model
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Identifier { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
