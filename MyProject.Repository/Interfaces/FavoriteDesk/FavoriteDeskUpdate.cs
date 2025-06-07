using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.FavoriteDesk
{
    public class FavoriteDeskUpdate
    {
        public SqlBoolean? IsFavorite { get; set; }
    }
}
