using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Desk
    {
        [Required]
        public int DeskId { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Zone can't be longer than 10.")]
        public string Zone { get; set; }
        [Required]
        public bool HasMonitor { get; set; }
        [Required]
        public bool HasDock { get; set; }
        [Required]
        public bool HasWindow { get; set; }
        [Required]
        public bool HasPrinter { get; set; }
    }
}
