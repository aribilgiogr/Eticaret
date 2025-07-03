using Eticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Eticaret.Controllers
{
    //[Authorize] //class içerisindeki bütün metotlara tek tek Authorize yazmak yerine class seviyesinde classın tepesine Authorize ekleriz.
    public class OperatorController : Controller
    {
        [Authorize(Roles = "Operator")]
        public IActionResult Liste()
        {
            return View(BooksDataLoad());
        }

        public List<Kitap> BooksDataLoad()
        {
            List<Kitap> books = new List<Kitap>();
            books.Add(new Kitap() { KitapAdi = "Suç ve Ceza", Yazar = "Fyodor Dostoyevski", YayinYili = 1866, KitapTuru = "Roman / Klasik" });
            books.Add(new Kitap() { KitapAdi = "Kürk Mantolu Madonna", Yazar = "Sabahattin Ali", YayinYili = 1943, KitapTuru = "Roman / Aşk" });
            books.Add(new Kitap() { KitapAdi = "Yüzüklerin Efendisi", Yazar = "J.R.R. Tolkien", YayinYili = 1954, KitapTuru = "Fantastik" });
            books.Add(new Kitap() { KitapAdi = "Simyacı", Yazar = "Paulo Coelho", YayinYili = 1988, KitapTuru = "Roman / Felsefi" });
            books.Add(new Kitap() { KitapAdi = "Sefiller", Yazar = "Victor Hugo", YayinYili = 1862, KitapTuru = "Roman / Dram" });
            books.Add(new Kitap() { KitapAdi = "1984", Yazar = "George Orwell", YayinYili = 1949, KitapTuru = "Distopya / Politik" });
            books.Add(new Kitap() { KitapAdi = "Hayvan Çiftliği", Yazar = "George Orwell", YayinYili = 1945, KitapTuru = "Alegori / Politik" });
            books.Add(new Kitap() { KitapAdi = "Tutunamayanlar", Yazar = "Oğuz Atay", YayinYili = 1971, KitapTuru = "Roman / Modern" });
            books.Add(new Kitap() { KitapAdi = "Satranç", Yazar = "Stefan Zweig", YayinYili = 1942, KitapTuru = "Novella / Psikoloji" });
            books.Add(new Kitap() { KitapAdi = "Da Vinci Şifresi", Yazar = "Dan Brown", YayinYili = 2003, KitapTuru = "Gerilim / Polisiye" });
            books.Add(new Kitap() { KitapAdi = "Uçurtma Avcısı", Yazar = "Khaled Hosseini", YayinYili = 2003, KitapTuru = "Roman / Dram" });
            books.Add(new Kitap() { KitapAdi = "Şeker Portakalı", Yazar = "José Mauro de Vasconcelos", YayinYili = 1968, KitapTuru = "Roman / Çocuk" });
            books.Add(new Kitap() { KitapAdi = "Vadideki Zambak", Yazar = "Honoré de Balzac", YayinYili = 1835, KitapTuru = "Klasik / Aşk" });
            books.Add(new Kitap() { KitapAdi = "Harry Potter ve Felsefe Taşı", Yazar = "J.K. Rowling", YayinYili = 1997, KitapTuru = "Fantastik / Genç" });
            books.Add(new Kitap() { KitapAdi = "Dönüşüm", Yazar = "Franz Kafka", YayinYili = 1915, KitapTuru = "Novella / Alegori" });
            books.Add(new Kitap() { KitapAdi = "Fahrenheit 451", Yazar = "Ray Bradbury", YayinYili = 1953, KitapTuru = "Distopya / Bilimkurgu" });
            books.Add(new Kitap() { KitapAdi = "Beyaz Diş", Yazar = "Jack London", YayinYili = 1906, KitapTuru = "Macera / Doğa" });
            books.Add(new Kitap() { KitapAdi = "İnce Memed", Yazar = "Yaşar Kemal", YayinYili = 1955, KitapTuru = "Roman / Toplumcu" });
            books.Add(new Kitap() { KitapAdi = "Binbir Gece Masalları", Yazar = "Anonim", YayinYili = 1300, KitapTuru = "Masal / Klasik" });
            books.Add(new Kitap() { KitapAdi = "Körlük", Yazar = "José Saramago", YayinYili = 1995, KitapTuru = "Roman / Alegori" });

            return books;
        }

        [Authorize(Roles = "Operator,Admin")] //birden fazla yetkiye aynı sayfayı açtık.
        public IActionResult hemAdminHemOp()
        {
            //string deger="muhammed";
            //Console.WriteLine($"{deger} değeri çok iyi bir değerdir.");
            return View();
        }

        //[Authorize(Policy ="user.ban")]



    }
}
