using System.Xml;

namespace Sube1.EntityApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ogr = new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 };

            //using (var ctx = new OkulDbContext())//garbage collector dbcontex'i dispose etmez
            //{
            //    ctx.Ogrenciler.Add(ogr);//added yapıldı
            //    ctx.SaveChanges();//insert komutu yapıcak
            //}

            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(1);
            //    if (ogr!=null)
            //    {
            //        ogr.Numara = 789;//moddifed yapılır
            //        ctx.SaveChanges();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Öğrenci Bulunamadı!");
            //    }
            //}

            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(2);
            //    ctx.Ogrenciler.Remove(ogr); //deleted
            //    ctx.SaveChanges();
            //}

            using (var ctx = new OkulDbContext())
            {
                var lst=ctx.Ogrenciler.ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.Ad);
                }
            }

        }
    }
}
//orm:object relational mapping
//entity framework code first
//entity
//model class
//DbContext: DB işlemleri için gerekli class
//DbSet:Db'deki tablolarun ran'deki karşılığı
//EntityState Ogrenciid Ad Soyad Numara ->kolonlar
// Added              Ali  Veli    123
//Modified      2      Ahmet Mehmet 789  
//Model-> DbSet -> SaveChanges() -> DB
//Model DbContext DbSet ConnectionString Migration
//başlangıç da ve pacakemanger consolde çalışacak projeyi seç