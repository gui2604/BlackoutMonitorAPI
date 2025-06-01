using BlackoutMonitorAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackoutMonitorAPI.Model
{
    public class Alert
    {
        [Key]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Required]
        public string Message { get; set; }

        // Relacionamento com Region
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int UserId { get; set; }  
        public User User { get; set; } 
    }
}
