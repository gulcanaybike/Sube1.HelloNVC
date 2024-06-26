﻿namespace Sube1.HelloNVC.Models
{
    public class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }

        public ICollection<OgrenciDers> OgrenciDersleri { get; set; }
        public override string ToString()
        {
            return $"Ad {Ad}- Soyad{Soyad}- Numara:{Numara}";
        }
    }
}
