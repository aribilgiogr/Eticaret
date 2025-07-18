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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(ApplicationDbContext _dbcontext, EticaretDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            dbContext = _dbcontext;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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


        //Admin panelde sol menüde bulunan Blog elemanına tıklanınca bu metot devreye girmeli.
        //Blog sayfasını açmalı. İlk  açılışta Blog verilerini görelim. Blog verilerinin içerisindeki edit,details vs gibi linklerin adreslerini güncelleyelim.
        public IActionResult Blog()
        {
           
            return View(_context.Blog.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile photo,Blog blog)
        {
            if(photo!=null && photo.Length > 0)
            {
                var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads"); //projenin kök dosya uzantısı ile uploads kısmını birleştirip fotografların yükleneceği dosya uzantısı elde ettik.

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var filePath = Path.Combine(uploadFolder, photo.FileName);

                using(var stream=new FileStream(filePath,FileMode.Create))
                {
                    photo.CopyTo(stream);
                }

                blog.FotoPath = filePath;
                _context.Blog.Add(blog);
                _context.SaveChanges();
            }

            return RedirectToAction("Blog", "Home");  //Blog ekleme işlemi sonrasında otomatik olarak Blog Listeleme view'ına gitsin.
        }


    }
}
