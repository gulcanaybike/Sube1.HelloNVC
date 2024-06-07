using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube1.HelloNVC.Models;
using System.Collections.Generic;

namespace Sube1.HelloNVC.Controllers
{
    public class OgrenciDersleriController : Controller
    {
        public IActionResult Index()
        {
            List<OgrenciDers> lst = null;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.ogrenciDersler.ToList();
            }
            return View(lst);

            //return View();
        }


        //public IActionResult Index(int ogrenciid)
        //{
        //    List<Ders> alinanDersler = null;
        //    using (var ctx = new OkulDbContext())
        //    {
        //        var ogr = ctx.Ogrenciler.Include(o => o.OgrenciDersleri).ThenInclude(d => d.ders).FirstOrDefault(o => o.Ogrenciid == ogrenciid);
        //        if (ogr == null)
        //        {
        //            return NotFound(); // Öğrenci bulunamadı
        //        }

        //        alinanDersler = ogr.OgrenciDersleri.Select(d => d.ders).ToList();


        //    }
        //    return View(alinanDersler);
        //}


        [HttpGet]
        public IActionResult alinanDersler(int ogrenciid)
        {
            /* List<Ders> alinanDersler = null;
             using (var ctx = new OkulDbContext())
             {
                 var ogr = ctx.Ogrenciler.Include(o => o.OgrenciDersleri).ThenInclude(d => d.ders).FirstOrDefault(o => o.Ogrenciid == ogrenciid);
                 if (ogr == null)
                 {
                     return NotFound();
                 }
                 alinanDersler = ogr.OgrenciDersleri.Select(d => d.ders).ToList();
             }
             return View(alinanDersler);*/

            List<OgrenciDers> ogDersleri;
            using (var ctx = new OkulDbContext())
            {
                ogDersleri = ctx.ogrenciDersler.Include(od => od.ders).Include(od => od.Ogrenci).Where(od => od.Ogrenciid == ogrenciid).ToList();
                ViewBag.OgrenciId = ogrenciid;
            }
            return View(ogDersleri);
        }
        [HttpGet]
        public IActionResult OgrenciDersEkle(int ogrenciid)
        {
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.ogrenciDersler.Where(od => od.Ogrenciid == ogrenciid).Select(od => od.Dersid).ToList();

                var lst2 = ctx.Dersler.Where(d => !lst.Contains(d.Dersid)).ToList();
                ViewData["OgrenciId"] = ogrenciid;
                return View(lst2);
            }
        }

        [HttpPost]
        public IActionResult OgrenciDersEkle(int ogrenciid, int dersid)
        {
            /* using (var ctx = new OkulDbContext())
             {
                 var ogr = ctx.Ogrenciler.Find(ogrenciid);
                 var ders = ctx.Dersler.Find(dersid);

                 if (ders == null || ogr == null)
                 {
                     return NotFound();
                 }

                 var ogrenciDers = new OgrenciDers
                 {
                     Ogrenciid = ogrenciid,
                     Dersid = dersid
                 };
                 ctx.ogrenciDersler.Add(ogrenciDers);
                 ctx.SaveChanges();

                 return RedirectToAction("Index");
             }*/
            var ogrenciDers = new OgrenciDers
            {
                Ogrenciid = ogrenciid,
                Dersid = dersid
            };
            using (var ctx = new OkulDbContext())
            {
                ctx.ogrenciDersler.Add(ogrenciDers);
                ctx.SaveChanges();
            }
            return RedirectToAction("alinanDersler", new {Ogrenciid=ogrenciid});
        }
    }
}
