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
        public async Task<AddFavoriteResponse> AddToUserFavorites(AddFavoriteRequest request)
        {
            if (request.DeskId <= 0 || request.UserId <= 0)
            {
                return new AddFavoriteResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid DeskId or UserId."
                };
            }
            var checkIfExists = await _favoriteDeskRepository.RetrieveCollectionAsync(new FavoriteDeskFilter { UserId = request.UserId }).ToListAsync();

            int count = 0;
            foreach (var favoriteDesk in checkIfExists)
            {
                if (favoriteDesk.IsFavorite)
                    count++;
            }
            if (count >= 3)
            {
                return new AddFavoriteResponse
                {
                    Success = false,
                    ErrorMessage = "You can only have 3 favorite desks."
                };
            }
            var existing = checkIfExists.FirstOrDefault(f => f.DeskId == request.DeskId);
            if (existing != null)
            {
                if (existing.IsFavorite)
                {
                    return new AddFavoriteResponse
                    {
                        Success = false,
                        ErrorMessage = "This desk is already in your favorites."
                    };
                }
                else
                {
                    existing.IsFavorite = true;
                    await _favoriteDeskRepository.UpdateAsync(existing.FavoriteDeskId, new FavoriteDeskUpdate { IsFavorite = existing.IsFavorite });
                    return new AddFavoriteResponse
                    {
                        Success = true,
                        ErrorMessage = "Desk added to favorites successfully."
                    };
                }
            }

            var newFavoriteDesk = new Models.FavoriteDesk
            {
                UserId = request.UserId,
                DeskId = request.DeskId,
                IsFavorite = true
            };
            var favoriteDeskId = await _favoriteDeskRepository.CreateAsync(newFavoriteDesk);
            if (favoriteDeskId > 0)
            {
                return new AddFavoriteResponse
                {
                    Success = true,
                    ErrorMessage = "Desk added to favorites successfully."
                };
            }
            else
            {
                return new AddFavoriteResponse
                {
                    Success = false,
                    ErrorMessage = "Failed to add desk to favorites."
                };
            }
        }
        public async Task<RemoveFavoriteResponse> RemoveFromUserFavorites(RemoveFavoriteRequest request)
        {
            if (request.UserId <= 0 || request.DeskId <= 0)
            {
                return new RemoveFavoriteResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid UserId or DeskId."
                };
            }

            var favoriteDesk = await _favoriteDeskRepository.RetrieveCollectionAsync(new FavoriteDeskFilter { UserId = request.UserId, DeskId = request.DeskId }).FirstOrDefaultAsync();
            if (favoriteDesk == null || !favoriteDesk.IsFavorite)
            {
                return new RemoveFavoriteResponse
                {
                    Success = false,
                    ErrorMessage = "This desk is not in your favorites."
                };
            }
            if (favoriteDesk != null && favoriteDesk.IsFavorite)
            {
                favoriteDesk.IsFavorite = false;
                await _favoriteDeskRepository.UpdateAsync(favoriteDesk.FavoriteDeskId, new FavoriteDeskUpdate { IsFavorite = favoriteDesk.IsFavorite });
                return new RemoveFavoriteResponse
                {
                    Success = true,
                    ErrorMessage = "Desk removed from favorites successfully."
                };
            }
            else
            {
                return new RemoveFavoriteResponse
                {
                    Success = false,
                    ErrorMessage = "Failed to remove desk from favorites."
                };
            }
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
