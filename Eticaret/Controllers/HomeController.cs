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
            KategorileriEkle();
            UrunDatalariniEkle();
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

     

        private void UrunDatalariniEkle()
        {
            List<Urun> urunler = new List<Urun> { 
    
        new Urun { UrunAd = "Akýllý Telefon", UrunFiyati = 22999, Marka = "Samsung", Model = "Galaxy S23",KategoriId=1,FotoPath="https://static.ticimax.cloud/14402/uploads/urunresimleri/buyuk/iphone-7-plus-32-gb-akilli-telefon-siyah-ac6d.jpg" },
        new Urun { UrunAd = "Dizüstü Bilgisayar", UrunFiyati = 35999, Marka = "Apple", Model = "MacBook Air M2",KategoriId=2 ,FotoPath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSo2ucxv6lpa33AQo4ZjPlb_dyPEIxXFsCjpw&s"},
        new Urun { UrunAd = "Tablet", UrunFiyati = 8499, Marka = "Lenovo", Model = "Tab P11",KategoriId=3 ,FotoPath="~/images/tablet.jpg" },
        new Urun { UrunAd = "Kulaklýk", UrunFiyati = 1899, Marka = "Sony", Model = "WH-CH720N",KategoriId=5 ,FotoPath="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/jbl/thumb/139117-1_large.jpg" },
        new Urun { UrunAd = "Akýllý Saat", UrunFiyati = 5299, Marka = "Huawei", Model = "Watch GT 4",KategoriId=4 ,FotoPath="https://productimages.hepsiburada.net/s/258/375-375/110000241885336.jpg" },
        new Urun { UrunAd = "Bluetooth Hoparlör", UrunFiyati = 1199, Marka = "JBL", Model = "Flip 6",KategoriId=5 ,FotoPath="https://static.ticimax.cloud/55525/uploads/urunresimleri/buyuk/24df9c39-6fb2-42af-9258-d73bab096be7-4cec80.jpg" },
        new Urun { UrunAd = "Televizyon", UrunFiyati = 16999, Marka = "LG", Model = "55NANO766QA",KategoriId=6 ,FotoPath="https://ae01.alicdn.com/kf/S2aab2d53679a429ea4c47281602c1f50p.jpg" },
        new Urun { UrunAd = "Klavye", UrunFiyati = 749, Marka = "Logitech", Model = "MX Keys",KategoriId=2 ,FotoPath="https://www.atombilisim.com.tr/turbox-giantpeak-usb-kablolu-rgb-makro-gaming-klavye-standart-q-sese-duyarli-rgb-isikli-macrolu-telefon-tutacakli-gaming-klavye-turbox-gaming-klavye-66511-72-B.jpg" },
        new Urun { UrunAd = "Fare", UrunFiyati = 499, Marka = "SteelSeries", Model = "Rival 3",KategoriId=2 ,FotoPath="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c07887338.png" },
        new Urun { UrunAd = "Monitör", UrunFiyati = 4499, Marka="Acer", Model = "R240HY",KategoriId=2 ,FotoPath="https://cdn.akakce.com/z/lg/lg-24mp60g-b-24-1ms-full-hd-freesync-oyuncu-u.jpg" } };


            if(_context.Urun.ToList().Count==0)
            {
                foreach (var item in urunler)
                {
                    _context.Urun.Add(item);
                    _context.SaveChanges();
                }
            }
        }

        public void KategorileriEkle()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            kategoriler.Add(new Kategori { KategoriAd = "Telefon ve Aksesuarlar", KategoriFotoPath= "https://www.aydiniletisim.com.tr/uploads/blog/en-populer-akilli-telefon-aksesuarlari-D4XM7J9P.jpg" });
            kategoriler.Add(new Kategori { KategoriAd = "Bilgisayar ve Bileþenleri",KategoriFotoPath= "https://media.istockphoto.com/id/619052288/tr/foto%C4%9Fraf/laptop-and-computer-parts.jpg?s=612x612&w=0&k=20&c=OaSXv01XuunCHRgIrAe56EiZTktEGwoHXBXH5C1xmSE=" });
            kategoriler.Add(new Kategori { KategoriAd = "Tablet ve E-kitap Okuyucular", KategoriFotoPath= "https://blog.teknosa.com/wp-content/uploads/2023/08/choosing-a-buying-book-and-internet-book-store-concept.jpg" });
            kategoriler.Add(new Kategori { KategoriAd = "Giyilebilir Teknolojiler",KategoriFotoPath= "https://www.academypeak.com/theme/images/giyilebilir-teknoloji-nedir.jpg" });
            kategoriler.Add(new Kategori { KategoriAd = "Ses Sistemleri",KategoriFotoPath= "https://www.yonkamuzikmarket.com/uploads/urunler/lastvoice-bronz-paket-2-profesyonel-ses-sistemi-mikser-hoparlor-ekipman-seti-94520.webp" });
            kategoriler.Add(new Kategori { KategoriAd = "Televizyon ve Görüntü Sistemleri",KategoriFotoPath= "https://www.axen.com.tr/wp-content/uploads/2022/11/webOS-Tizen-Android-isletim-sistemleri-nedir-aralarindaki-farklar-nelerdir-1.webp" });

            if (_context.Kategori.ToList().Count == 0)
            {
                foreach (var item in kategoriler)
                {
                    _context.Kategori.Add(item);
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
