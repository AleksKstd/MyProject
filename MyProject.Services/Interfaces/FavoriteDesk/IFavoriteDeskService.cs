using MyProject.Services.DTOs.FavoriteDesk;

namespace MyProject.Services.Interfaces.FavoriteDesk
{
    public interface IFavoriteDeskService
    {
        Task<GetAllFavoritesByUserIdResponse> GetAllUserFavoritesAsync(int userId);
        Task<AddFavoriteResponse> AddToUserFavorites(AddFavoriteRequest request);
    }
}
