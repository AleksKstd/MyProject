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
    public IActionResult CreateReservation(int deskId)
    {
        if (deskId <= 0) 
        {
            TempData["ErrorMessage"] = "Invalid desk ID provided.";
            return RedirectToAction("Index");
        }
        var model = new ReservationViewModel
        {
            DeskId = deskId,
            Date = DateTime.UtcNow
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation(ReservationViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var request = new CreateReservationRequest
        {
            DeskId = model.DeskId,
            UserId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault(),
            Date = model.Date,
            IsActive = true
        };

        var response = await _reservationService.CreateReservation(request);
        if (!response.Success)
        {
            TempData["ErrorMessage"] = response.ErrorMessage;
            return View(model);          
        }

        return RedirectToAction("Index", "Reservation");
    }

    [HttpGet]
    public IActionResult CreateQuickReservation(int deskId)
    {
        if (deskId <= 0)
        {
            TempData["ErrorMessage"] = "Invalid desk ID provided.";
            return RedirectToAction("Index", "Home");
        }
        var model = new ReservationViewModel
        {
            DeskId = deskId,
            Date = DateTime.UtcNow
        };
        return RedirectToAction("CreateQuickReservation", "Reservation");
    }
    [HttpPost]
    public async Task<IActionResult> CreateQuickReservation(ReservationViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var request = new CreateReservationRequest
        {
            DeskId = model.DeskId,
            UserId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault(),
            Date = DateTime.UtcNow.AddDays(1),
            IsActive = true
        };
        var response = await _reservationService.CreateReservation(request);
        if (!response.Success)
        {
            TempData["ErrorMessage"] = response.ErrorMessage;
            return View(model);
        }
        return RedirectToAction("Index", "Home");
    }
}

