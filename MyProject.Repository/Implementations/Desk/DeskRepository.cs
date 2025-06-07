using Microsoft.Data.SqlClient;
using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.Desk;

namespace MyProject.Repository.Implementations.Desk
{
    public class DeskRepository : BaseRepository<Models.Desk>, IDeskRepository
    {
        protected override string[] GetColumns()
        {
            return new[]
            {
                "DeskId",
                "Floor",
                "Zone",
                "HasMonitor",
                "HasDock",
                "HasWindow",
                "HasPrinter"
            };
        }

        protected override string GetTableName()
        {
            return "Desks";
        }

        protected override Models.Desk MapToEntity(SqlDataReader reader)
        {
            return new Models.Desk
            {
                DeskId = Convert.ToInt32(reader["DeskId"]),
                Floor = Convert.ToInt32(reader["Floor"]),
                Zone = Convert.ToString(reader["Zone"]),
                HasMonitor = Convert.ToBoolean(reader["HasMonitor"]),
                HasDock = Convert.ToBoolean(reader["HasDock"]),
                HasWindow = Convert.ToBoolean(reader["HasWindow"]),
                HasPrinter = Convert.ToBoolean(reader["HasPrinter"])
            };
        }
        public Task<int> CreateAsync(Models.Desk entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Desk> RetrieveAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Models.Desk> RetrieveCollectionAsync(DeskFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, DeskUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
