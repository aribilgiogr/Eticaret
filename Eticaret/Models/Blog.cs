using System.Reflection.Metadata;

namespace Eticaret.Models
{
    public class Blog
    {
        //blog id
        //blog görseli
        //blog metni
        //blog yazarı

        public int BlogId { get; set; }
        public string FotoPath { get; set; }
        public string BlogMetni { get; set; }
        public string BlogYazari { get; set; }
    }
}
