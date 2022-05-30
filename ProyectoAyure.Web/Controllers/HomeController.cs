using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoAyure.Data.ViewModels;
using ProyectoAyure.Web.Models;
using System.Diagnostics;

namespace ProyectoAyure.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [Authorize]
        public IActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Login");

            return View();
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