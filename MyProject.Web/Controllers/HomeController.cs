using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyProject.Services.Interfaces.Desk;
using MyProject.Services.Interfaces.FavoriteDesk;
using MyProject.Web.Models;

namespace MyProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeskService _deskService;
        private readonly IFavoriteDeskService _favoriteDeskService;

        public HomeController(IDeskService deskService, IFavoriteDeskService favoriteDeskService)
        {
            _deskService = deskService;
            _favoriteDeskService = favoriteDeskService;
        }

        public async Task<IActionResult> Index()
        {
            if (!HttpContext.Session.GetInt32("UserId").HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var allDesksFromService = await _deskService.GetAllDesksAsync();
            var favoriteDeskIds = await _favoriteDeskService.GetAllUserFavoritesAsync(HttpContext.Session.GetInt32("UserId").Value);

            var allDesks = new List<DeskViewModel>();
            var favoriteDesks = new List<DeskViewModel>();

            if (favoriteDeskIds.TotalCount == 0)
            {
                foreach (var favoriteInstance in favoriteDeskIds.UserFavorites)
                {
                    var desk = await _deskService.GetDeskByIdAsync(favoriteInstance.DeskId);
                    if (desk != null)
                    {
                        favoriteDesks.Add(new DeskViewModel
                        {
                            DeskId = desk.DeskId,
                            Floor = desk.Floor,
                            Zone = desk.Zone,
                            HasMonitor = desk.HasMonitor,
                            HasDock = desk.HasDock,
                            HasWindow = desk.HasWindow,
                            HasPrinter = desk.HasPrinter
                        });
                    }
                }
            }
            foreach (var deskFromService in allDesksFromService.Desks)
            {
                if (deskFromService != null)
                {
                    favoriteDesks.Add(new DeskViewModel
                    {
                        DeskId = deskFromService.DeskId,
                        Floor = deskFromService.Floor,
                        Zone = deskFromService.Zone,
                        HasMonitor = deskFromService.HasMonitor,
                        HasDock = deskFromService.HasDock,
                        HasWindow = deskFromService.HasWindow,
                        HasPrinter = deskFromService.HasPrinter
                    });
                }
            }

            var viewModel = new HomeViewModel
            {
                AllDesks = allDesks,
                FavoriteDesks = favoriteDesks
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
