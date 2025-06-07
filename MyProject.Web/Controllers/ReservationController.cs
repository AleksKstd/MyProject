using Microsoft.AspNetCore.Mvc;
using MyProject.Services.DTOs.Reservation;
using MyProject.Services.Interfaces.Reservation;

public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;
    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest reservation)
    {
        if (reservation == null)
        {
            TempData["ErrorMessage"] = "No reservation data given";
        }

        var response = await _reservationService.CreateReservation(reservation);
        if (!response.Success)
        {
            TempData["ErrorMessage"] = response.ErrorMessage;
        }
        return RedirectToAction(response);
    }
}

