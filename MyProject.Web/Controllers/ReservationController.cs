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

    public async Task<IActionResult> Index()
    {
        if (!HttpContext.Session.GetInt32("UserId").HasValue)
        {
            return RedirectToAction("Login", "Account");
        }
        var userId = (int)HttpContext.Session.GetInt32("UserId");
        var response = await _reservationService.GetAllUserReservations(userId);
        if(response.TotalCount == 0)
        {
            TempData["ErrorMessage"] = "No reservations found.";
        }
        var reservations = new List<ReservationViewModel>();
        foreach (var reservation in response.Reservations)
        {
            reservations.Add(new ReservationViewModel
            {
                ReservationId = reservation.ReservationId,
                DeskId = reservation.DeskId,
                UserId = reservation.UserId,
                Date = reservation.Date,
                IsActive = reservation.IsActive
            });
        }

        UserReservationViewModel viewModel = new UserReservationViewModel
        {
            Reservations = reservations
        };
        return View(viewModel);
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateReservation(int deskId)
    {
        if (deskId <= 0)
        {
            TempData["ErrorMessage"] = "Invalid desk ID";
            return RedirectToAction("Home/Index");
        }
        var reservation = new CreateReservationRequest
        {
            DeskId = deskId,
            UserId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault(),
            Date = DateTime.Now 
        };
        if (reservation == null)
        {
            TempData["ErrorMessage"] = "No reservation data given";
        }

        var response = await _reservationService.CreateReservation(reservation);
        if (!response.Success)
        {
            TempData["ErrorMessage"] = response.ErrorMessage;
        }
        return RedirectToAction("CreateReservation");
    }
}

