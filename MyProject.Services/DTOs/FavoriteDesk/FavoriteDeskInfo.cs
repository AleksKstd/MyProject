namespace MyProject.Services.DTOs.FavoriteDesk
{
    public class FavoriteDeskInfo
    {
        public int FavoriteDeskId { get; set; }
        public int UserId { get; set; }
        public int DeskId { get; set; }
        public bool IsFavorite { get; set; }
    }
}
