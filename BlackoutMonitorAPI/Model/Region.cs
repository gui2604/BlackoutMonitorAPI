using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackoutMonitorAPI.Model
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public required string Cep { get; set; }

        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public ICollection<Device>? Devices { get; set; }
    }
}
