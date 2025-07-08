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

        [AllowAnonymous] //kimlik dogrulama gerektirmeden eri�imi herkese a�ar

        public IActionResult Index()
        {
            OgrenciDatalariniEkle();
            DersAdlariniEkle();
            return View();
        }

        private void DersAdlariniEkle()
        {
            List<Ders> dersler = new List<Ders>();
            dersler.Add(new Ders { DersAd = "Matematik", DersKredisi = 3, DersAciklama = "En g�c�k ders" });
            dersler.Add(new Ders { DersAd = "Fizik", DersKredisi = 4, DersAciklama = "En zor ders" });
            dersler.Add(new Ders { DersAd = "Kimya", DersKredisi = 3, DersAciklama = "En e�lenceli ders" });
            dersler.Add(new Ders { DersAd = "Biyoloji", DersKredisi = 2, DersAciklama = "En ilgin� ders" });
            dersler.Add(new Ders { DersAd = "Tarih", DersKredisi = 3, DersAciklama = "En ��retici ders" });
            dersler.Add(new Ders { DersAd = "Co�rafya", DersKredisi = 2, DersAciklama = "En geni� ders" });
            dersler.Add(new Ders { DersAd = "Edebiyat", DersKredisi = 3, DersAciklama = "En g�zel ders" });
            dersler.Add(new Ders { DersAd = "Felsefe", DersKredisi = 2, DersAciklama = "En derin ders" });
            dersler.Add(new Ders { DersAd = "M�zik", DersKredisi = 1, DersAciklama = "En e�lenceli ders" });
            dersler.Add(new Ders { DersAd = "Resim", DersKredisi = 1, DersAciklama = "En yarat�c� ders" });
            dersler.Add(new Ders { DersAd = "Bilgisayar", DersKredisi = 4, DersAciklama = "En pop�ler ders" });
            dersler.Add(new Ders { DersAd = "Spor", DersKredisi = 2, DersAciklama = "En aktif ders" });
            dersler.Add(new Ders { DersAd = "Yabanc� Dil", DersKredisi = 3, DersAciklama = "En faydal� ders" });

            //e�er tabloda kay�t varsa ekleme yoksa ekle.
            if (_context.Ders.ToList().Count == 0)  //tabloda kay�t yoksa 0 ise
            {
                //hi� kay�t eklenmemi� ekle.
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
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Ali", OgrenciSoyad = "Y�lmaz", OgrenciNo = "20" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Ay�e", OgrenciSoyad = "Demir", OgrenciNo = "21" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Mehmet", OgrenciSoyad = "Kara", OgrenciNo = "22" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Fatma", OgrenciSoyad = "�elik", OgrenciNo = "23" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Ahmet", OgrenciSoyad = "�zt�rk", OgrenciNo = "24" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Elif", OgrenciSoyad = "Ko�", OgrenciNo = "25" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Zeynep", OgrenciSoyad = "Ayd�n", OgrenciNo = "26" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Emre", OgrenciSoyad = "Polat", OgrenciNo = "27" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Seda", OgrenciSoyad = "Yurt", OgrenciNo = "28" });
            ogrenciler.Add(new Ogrenci { OgrenciAd = "Can", OgrenciSoyad = "Kaya", OgrenciNo = "29" });

            //e�er tabloda kay�t varsa ekleme yoksa ekle.
            if (_context.Ogrenci.ToList().Count == 0)  //tabloda kay�t yoksa 0 ise
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
