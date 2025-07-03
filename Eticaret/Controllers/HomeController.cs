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

        [AllowAnonymous] //kimlik dogrulama gerektirmeden eri�imi herkese a�ar

        public IActionResult Index()
        {           
            return View();
        }
        
        public void RolEkle()
        {
            //e�er kod yazarak rol eklemek istersek bu metodun i�ini doldurabiliriz.

        }

        //User'a Rol Atamas�n� AspNetUserRoles tablosuna ekleyerek yapt�k.


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
