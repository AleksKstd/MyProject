using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.FavoriteDesk;
using Microsoft.Data.SqlClient;

namespace MyProject.Repository.Implementations.FavoriteDesk
{
    public class FavoriteDeskRepository : BaseRepository<Models.FavoriteDesk>, IFavoriteDeskRepository
    {
        protected override string[] GetColumns()
        {
            return new[]
            {
                "FavoriteDeskId",
                "UserId",
                "DeskId",
                "IsFavorite"
            };
        }

        protected override string GetTableName()
        {
            return "FavoriteDesks";
        }

        protected override Models.FavoriteDesk MapToEntity(SqlDataReader reader)
        {
            return new Models.FavoriteDesk
            {
                FavoriteDeskId = Convert.ToInt32(reader["FavoriteDeskId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                DeskId = Convert.ToInt32(reader["DeskId"]),
                IsFavorite = Convert.ToBoolean(reader["IsFavorite"])
            };
        }

        public Task<int> CreateAsync(Models.FavoriteDesk entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.FavoriteDesk> RetrieveAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Models.FavoriteDesk> RetrieveCollectionAsync(FavoriteDeskFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, FavoriteDeskUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
