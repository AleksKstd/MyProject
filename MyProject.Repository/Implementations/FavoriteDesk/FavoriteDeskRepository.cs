using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.FavoriteDesk;
using Microsoft.Data.SqlClient;
using MyProject.Repository.Helpers;

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

        public async Task<int> CreateAsync(Models.FavoriteDesk entity)
        {
            return await base.CreateAsync(entity, "FavoriteDeskId");
        }

        public async Task<bool> DeleteAsync(int objectId)
        {
            return await base.DeleteAsync("FavoriteDeskId", objectId);
        }

        public async Task<Models.FavoriteDesk> RetrieveAsync(int objectId)
        {
            return await base.RetrieveAsync("FavoriteDeskId", objectId);
        }

        public IAsyncEnumerable<Models.FavoriteDesk> RetrieveCollectionAsync(FavoriteDeskFilter filter)
        {
            Filter commandFilter = new Filter();

            if (filter.UserId is not null)
            {
                commandFilter.AddCondition("UserId", filter.UserId.Value);
            }
            if (filter.IsFavorite is not null)
            {
                commandFilter.AddCondition("IsFavorite", filter.IsFavorite.Value);
            }

            return base.RetrieveCollectionAsync(commandFilter);
        }

        public async Task<bool> UpdateAsync(int objectId, FavoriteDeskUpdate update)
        {
            SqlConnection connection = await ConnectionFactory.CreateConnectionAsync();

            Update updateCommand = new Update(
                connection,
                GetTableName(),
                "FavoriteDeskId",
                objectId);

            updateCommand.AddSetClause("IsFavorite", update.IsFavorite);

            return await updateCommand.ExecuteNonQueryAsync() > 0;
        }
    }
}
