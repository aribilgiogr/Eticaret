using System.Diagnostics;
using Eticaret.Data;
using Eticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Controllers
{
    //[Authorize] 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EticaretDBContext _context;


        public HomeController(ILogger<HomeController> logger, EticaretDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous] //kimlik dogrulama gerektirmeden eriþimi herkese açar

        public IActionResult Index()
        {
            OgrenciDatalariniEkle();
            DersAdlariniEkle();
            return View();
        }

        private void DersAdlariniEkle()
        {
            List<Ders> dersler = new List<Ders>();
            dersler.Add(new Ders { DersAd = "Matematik", DersKredisi = 3, DersAciklama = "En gýcýk ders" });
            dersler.Add(new Ders { DersAd = "Fizik", DersKredisi = 4, DersAciklama = "En zor ders" });
            dersler.Add(new Ders { DersAd = "Kimya", DersKredisi = 3, DersAciklama = "En eðlenceli ders" });
            dersler.Add(new Ders { DersAd = "Biyoloji", DersKredisi = 2, DersAciklama = "En ilginç ders" });
            dersler.Add(new Ders { DersAd = "Tarih", DersKredisi = 3, DersAciklama = "En öðretici ders" });
            dersler.Add(new Ders { DersAd = "Coðrafya", DersKredisi = 2, DersAciklama = "En geniþ ders" });
            dersler.Add(new Ders { DersAd = "Edebiyat", DersKredisi = 3, DersAciklama = "En güzel ders" });
            dersler.Add(new Ders { DersAd = "Felsefe", DersKredisi = 2, DersAciklama = "En derin ders" });
            dersler.Add(new Ders { DersAd = "Müzik", DersKredisi = 1, DersAciklama = "En eðlenceli ders" });
            dersler.Add(new Ders { DersAd = "Resim", DersKredisi = 1, DersAciklama = "En yaratýcý ders" });
            dersler.Add(new Ders { DersAd = "Bilgisayar", DersKredisi = 4, DersAciklama = "En popüler ders" });
            dersler.Add(new Ders { DersAd = "Spor", DersKredisi = 2, DersAciklama = "En aktif ders" });
            dersler.Add(new Ders { DersAd = "Yabancý Dil", DersKredisi = 3, DersAciklama = "En faydalý ders" });

            //eðer tabloda kayýt varsa ekleme yoksa ekle.
            if (_context.Ders.ToList().Count == 0)  //tabloda kayýt yoksa 0 ise
            {
                //hiç kayýt eklenmemiþ ekle.
                foreach (var item in dersler)
                {
                    _context.Ders.Add(item);
                    _context.SaveChanges();
                }
            }
        }

        private void OgrenciDatalariniEkle()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Ali", OgrenciSoyad = "Yýlmaz", OgrenciNo = "20" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Ayþe", OgrenciSoyad = "Demir", OgrenciNo = "21" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Mehmet", OgrenciSoyad = "Kara", OgrenciNo = "22" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Fatma", OgrenciSoyad = "Çelik", OgrenciNo = "23" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Ahmet", OgrenciSoyad = "Öztürk", OgrenciNo = "24" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Elif", OgrenciSoyad = "Koç", OgrenciNo = "25" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Zeynep", OgrenciSoyad = "Aydýn", OgrenciNo = "26" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Emre", OgrenciSoyad = "Polat", OgrenciNo = "27" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Seda", OgrenciSoyad = "Yurt", OgrenciNo = "28" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Can", OgrenciSoyad = "Kaya", OgrenciNo = "29" });

            //eðer tabloda kayýt varsa ekleme yoksa ekle.
            if (_context.Ogrenci.ToList().Count == 0)  //tabloda kayýt yoksa 0 ise
            {
                foreach (var item in ogrenciler)
                {
                    _context.Ogrenci.Add(item);
                    _context.SaveChanges();
                }
            }
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
