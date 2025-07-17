using Eticaret.Models;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Data
{
    public class EticaretDBContext :DbContext
    {
        public EticaretDBContext(DbContextOptions<EticaretDBContext> options) :base(options)
        {
            
        }

        //Ogrenci

        public DbSet<Ogrenci> Ogrenci { get; set; }

        //Ders
        public DbSet<Ders> Ders { get; set; } //DbSet<classAdi> tabloAdi {get;set;}

        //OgrenciDers tablosu için buraya modeli ekle.
        public DbSet<OgrenciDers> OgrenciDers { get; set; } 
        public DbSet<Urun> Urun { get; set; } 
        public DbSet<Kategori> Kategori { get; set; }


        //Blog tablosunu oluşturmak için buraya Blog classını ekleyelim.
        public DbSet<Blog> Blog { get; set; }
    }
}
