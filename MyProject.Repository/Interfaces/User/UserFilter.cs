using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.User
{
    public class UserFilter
    {
        public SqlInt32? UserId { get; set; }
        public SqlString? Username { get; set; }
    }
}
