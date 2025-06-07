namespace MyProject.Services.DTOs.Reservation
{
    public class GetAllReservationsForUserResponse
    {
        public List<ReservationInfo> Reservations { get; set; }
        public int TotalCount { get; set; }
    }
}
