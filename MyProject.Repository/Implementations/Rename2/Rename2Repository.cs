using Microsoft.Data.SqlClient;
using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.Rename2;

namespace MyProject.Repository.Implementations.Rename2
{
    public class Rename2Repository : BaseRepository<Models.Rename2>, IRename2Repository
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
        public Task<int> CreateAsync(Models.Rename2 entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Rename2> RetrieveAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Models.Rename2> RetrieveCollectionAsync(Rename2Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, Rename2Update update)
        {
            throw new NotImplementedException();
        }
    }
}
