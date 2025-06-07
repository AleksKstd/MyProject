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
                "UserId",
                "Username",
                "Password",
                "Email",
                "FullName"
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
                UserId = Convert.ToInt32(reader["UserId"]),
                Username = Convert.ToString(reader["Username"]),
                Password = Convert.ToString(reader["Password"]),
                Email = Convert.ToString(reader["Email"]),
                FullName = Convert.ToString(reader["FullName"])
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
