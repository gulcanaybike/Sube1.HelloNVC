namespace Sube1.HelloNVC.Models.ViewModels
{
    public class OgrenciVeDersler
    {
        public int OgrenciId { get; set; }
        public int DersId { get; set; }
        public IEnumerable<Ders> Dersler { get; set; }
    }
}
