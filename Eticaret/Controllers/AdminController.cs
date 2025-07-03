using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //[Authorize] //o an o sayfayı talep eden kişi login mi diye bakar. Eğer Login ise ilgili sayfayı açar. Eğer Login değilse otomatik olarak Login sayfasına redirect eder.(yönlendirme yapar.)

        //eğer Rolü Admin olan bu sayfayı açsın istersek

        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult KullaniciRolAta()
        {
            return View();
        }



    }
}
