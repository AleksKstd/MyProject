using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.Reservation
{
    public class ReservationUpdate
    {
        public SqlBoolean? IsActive { get; set; }
    }
}
