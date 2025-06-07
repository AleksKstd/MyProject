using MyProject.Repository.Interfaces.FavoriteDesk;
using MyProject.Services.DTOs.FavoriteDesk;
using MyProject.Services.Interfaces.FavoriteDesk;

namespace MyProject.Services.Implementations.FavoriteDesk
{
    public class FavoriteDeskService : IFavoriteDeskService
    {
        private readonly IFavoriteDeskRepository _favoriteDeskRepository;
        public FavoriteDeskService(IFavoriteDeskRepository favoriteDeskRepository)
        {
            _favoriteDeskRepository = favoriteDeskRepository;
        }
        public async Task<GetAllFavoritesByUserIdResponse> GetAllUserFavoritesAsync(int userId)
        {
            var userFavorites = await _favoriteDeskRepository.RetrieveCollectionAsync(new FavoriteDeskFilter { UserId = userId, IsFavorite = true }).ToListAsync();
            var favoriteDesks = new GetAllFavoritesByUserIdResponse
            {
                UserFavorites = userFavorites.Select(MapToFavoriteDeskInfo).ToList(),
                TotalCount = userFavorites.Count
            };

            return favoriteDesks;
        }
        private FavoriteDeskInfo MapToFavoriteDeskInfo(Models.FavoriteDesk favoriteDesk)
        {
            return new FavoriteDeskInfo
            {
                FavoriteDeskId = favoriteDesk.FavoriteDeskId,
                UserId = favoriteDesk.UserId,
                DeskId = favoriteDesk.DeskId,
                IsFavorite = favoriteDesk.IsFavorite
            };
        }
    }
}
