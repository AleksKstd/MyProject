using Microsoft.Data.SqlClient;
using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.User;

namespace MyProject.Repository.Implementations.User
{
    public class UserRepository : BaseRepository<Models.User>, IUserRepository
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
            return "Users";
        }

        protected override Models.User MapToEntity(SqlDataReader reader)
        {
            return new Models.User
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
        public Task<int> CreateAsync(Models.User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.User> RetrieveAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Models.User> RetrieveCollectionAsync(UserFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, UserUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
