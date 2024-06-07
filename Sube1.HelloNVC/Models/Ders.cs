namespace Sube1.HelloNVC.Models
{
    public class Ders
    {
        public int Dersid { get; set; }
        public string Dersad { get; set; }
       // public byte Kredi { get; set; }   
        public string DersKodu { get; set; }
        public ICollection<OgrenciDers> OgrenciDersleri { get; set; }
    }
}
