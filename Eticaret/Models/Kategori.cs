namespace Eticaret.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }

        public string KategoriFotoPath { get; set; }
        public List<Urun> Urunler { get; set; }
    }

}
