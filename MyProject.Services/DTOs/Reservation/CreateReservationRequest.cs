namespace MyProject.Services.DTOs.Reservation
{
    public class CreateReservationRequest
    {
        public int UserId { get; set; }
        public int DeskId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
