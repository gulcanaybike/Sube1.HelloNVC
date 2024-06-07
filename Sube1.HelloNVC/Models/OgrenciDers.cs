using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sube1.HelloNVC.Models
{
    public class OgrenciDers
    {
        public int Ogrenciid { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public int Dersid { get; set; }
        public Ders ders { get; set; } 
    }
}
