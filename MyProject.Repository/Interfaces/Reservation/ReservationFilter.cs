using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.Reservation
{
    public class ReservationFilter
    {
        public SqlInt32? UserId { get; set; }
        public SqlInt32? DeskId { get; set; }
        public SqlBoolean? IsActive { get; set; }
        public SqlDateTime? Date { get; set; }
    }
}
