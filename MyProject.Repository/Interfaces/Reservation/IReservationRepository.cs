using MyProject.Repository.Base;

namespace MyProject.Repository.Interfaces.Reservation
{
    public interface IReservationRepository : IBaseRepository<Models.Reservation, ReservationFilter, ReservationUpdate>
    {
    }
}
