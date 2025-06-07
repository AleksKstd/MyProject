using Microsoft.Data.SqlClient;
using MyProject.Repository.Base;
using MyProject.Repository.Helpers;
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
        public async Task<int> CreateAsync(Models.Desk entity)
        {
            return await base.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int objectId)
        {
            return await base.DeleteAsync("DeskId", objectId);
        }

        public async Task<Models.Desk> RetrieveAsync(int objectId)
        {
            return await base.RetrieveAsync("DeskId", objectId);
        }

        public IAsyncEnumerable<Models.Desk> RetrieveCollectionAsync(DeskFilter filter)
        {
            Filter commandFilter = new Filter();

            if (filter.Floor is not null)
            {
                commandFilter.AddCondition("Floor", filter.Floor.Value);
            }
            if (filter.HasDock is not null)
            {
                commandFilter.AddCondition("HasDock", filter.HasDock);
            }
            if (filter.HasMonitor is not null)
            {
                commandFilter.AddCondition("HasMonitor", filter.HasMonitor);
            }
            if (filter.HasWindow is not null)
            {
                commandFilter.AddCondition("HasWindow", filter.HasWindow);
            }
            if (filter.HasPrinter is not null)
            {
                commandFilter.AddCondition("HasPrinter", filter.HasPrinter);
            }

            return base.RetrieveCollectionAsync(commandFilter);
        }

        public Task<bool> UpdateAsync(int objectId, DeskUpdate update)
        {
            throw new NotImplementedException("Desks cannot be updated.");
        }
    }
}
