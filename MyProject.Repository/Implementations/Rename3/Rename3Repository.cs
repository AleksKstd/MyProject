using Microsoft.Data.SqlClient;
using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.Rename3;

namespace MyProject.Repository.Implementations.Rename3
{
    public class Rename3Repository : BaseRepository<Models.Rename3>, IRename3Repository
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

        protected override Models.Rename3 MapToEntity(SqlDataReader reader)
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
        public Task<int> CreateAsync(Models.Rename3 entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Rename3> RetrieveAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Models.Rename3> RetrieveCollectionAsync(Rename3Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, Rename3Update update)
        {
            throw new NotImplementedException();
        }
    }
}
