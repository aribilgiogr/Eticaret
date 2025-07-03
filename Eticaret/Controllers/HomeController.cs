using System.Diagnostics;
using Eticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Controllers
{
    //[Authorize] 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous] //kimlik dogrulama gerektirmeden eriþimi herkese açar

        public IActionResult Index()
        {           
            return View();
        }
        
        public void RolEkle()
        {
            //eðer kod yazarak rol eklemek istersek bu metodun içini doldurabiliriz.

        }

        //User'a Rol Atamasýný AspNetUserRoles tablosuna ekleyerek yaptýk.


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
