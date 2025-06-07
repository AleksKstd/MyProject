namespace MyProject.Services.DTOs.FavoriteDesk
{
    public class GetAllFavoritesByUserIdResponse
    {
        public List<FavoriteDeskInfo> UserFavorites { get; set; }
        public int TotalCount { get; set; }
    }
}
