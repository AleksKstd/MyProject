using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.User
{
    public class UserFilter
    {
        public SqlString? Username { get; set; }
    }
}
