using MyProject.Repository.Base;

namespace MyProject.Repository.Interfaces.FavoriteDesk
{
    public interface IFavoriteDeskRepository : IBaseRepository<Models.FavoriteDesk, FavoriteDeskFilter, FavoriteDeskUpdate>
    {
    }
}
