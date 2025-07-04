using Eticaret.Data;
using Eticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ApplicationDbContext dbContext;

        public AdminController(ApplicationDbContext _dbcontext)
        {
            dbContext = _dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KullaniciRolAta()
        {
            var kullaniciListesi = dbContext.Users.ToList();
            var rolListesi = dbContext.Roles.ToList();
            ViewBag.kullanicilar = new SelectList(kullaniciListesi, "Id", "UserName");
            ViewBag.roller = new SelectList(rolListesi, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult KullaniciRolAta(UserRol userrol)
        {
            // Convert UserRol to IdentityUserRole<string>
            var identityUserRole = new IdentityUserRole<string>
            {
                UserId = userrol.UserId,
                RoleId = userrol.RolId
            };

            dbContext.UserRoles.Add(identityUserRole);
            dbContext.SaveChanges(); 

            return View();
        }
    }
}
