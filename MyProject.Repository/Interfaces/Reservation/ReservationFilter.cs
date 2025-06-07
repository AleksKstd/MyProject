using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.Reservation
{
    public class ReservationFilter
    {
        public SqlInt32? ReservationId { get; set; }
        public SqlInt32? UserId { get; set; }
        public SqlDateTime? Date { get; set; }
    }
}
