using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class FavoriteDesk
    {
        [Required]
        public int FavoriteDeskId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DeskId { get; set; }
        [Required]
        public bool IsFavorite { get; set; }
    }
}
