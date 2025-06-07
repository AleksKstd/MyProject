namespace MyProject.Services.DTOs.Reservation
{
    public class ReservationInfo
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int DeskId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
