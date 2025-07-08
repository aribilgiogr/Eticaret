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

    }
}
