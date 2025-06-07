using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProject.Models
{
    public class Reservation
    {
        [Required]
        public int ReservationId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DeskId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public Date Date { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
