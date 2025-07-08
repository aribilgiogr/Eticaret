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
        public EticaretDBContext _context;

        public AdminController(ApplicationDbContext _dbcontext, EticaretDBContext context)
        {
            dbContext = _dbcontext;
            _context = context;
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

        public IActionResult OgrenciDersAta()
        {
            //ViewBag ile ogrenciler ve dersler datasını hazırla.
            var ogrenciListesi = _context.Ogrenci.ToList();
            var dersListesi = _context.Ders.ToList();
            ViewBag.ogrenciler = new SelectList(ogrenciListesi, "OgrenciId", "OgrenciAd");
            ViewBag.dersler = new SelectList(dersListesi, "DersId", "DersAd");
            return View();
        }

        [HttpPost]
        public IActionResult OgrenciDersAta(OgrenciDers ogrenciDers)
        {
            //gelen ogrenciders bilgisi ogrenciders tablosuna eklenecek.
            _context.OgrenciDers.Add(ogrenciDers);
            _context.SaveChanges();
            return View();
        }
    }
}
