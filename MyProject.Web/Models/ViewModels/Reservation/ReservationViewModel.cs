
public class UserReservationViewModel
{
    public List<ReservationViewModel> Reservations { get; set; }
}

public class ReservationViewModel
{
    public int ReservationId { get; set; }
    public int UserId { get; set; }
    public int DeskId { get; set; }
    public DateTime Date { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
}

