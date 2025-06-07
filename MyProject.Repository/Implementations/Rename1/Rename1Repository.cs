using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.Rename1;
using Microsoft.Data.SqlClient;

namespace MyProject.Repository.Implementations.Rename1
{
    public class Rename1Repository : BaseRepository<Models.Rename1>, IRenameRepository
    {
        protected override string[] GetColumns()
        {
            return new[]
            {
                "Rename",
                "Rename",
                "Rename",
                "Rename",
                "Rename"
            };
        }

        protected override string GetTableName()
        {
            return "Rename";
        }

        protected override Models.Rename1 MapToEntity(SqlDataReader reader)
        {
            return new Models.Rename1
            {
                Rename = Convert.ToInt32(reader["Rename"]),
                Rename = Convert.ToInt32(reader["Rename"]),
                Rename = Convert.ToDateTime(reader["Rename"]),
                Rename = Convert.ToDateTime(reader["Rename"]),
                Rename = Convert.ToString(reader["Rename"]),
                Rename = Convert.ToInt32(reader["Rename"]),
                Rename = Convert.ToBoolean(reader["Rename"])
            };
        }

        public Task<int> CreateAsync(Models.Rename1 entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Rename1> RetrieveAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Models.Rename1> RetrieveCollectionAsync(RenameFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, RenameUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
