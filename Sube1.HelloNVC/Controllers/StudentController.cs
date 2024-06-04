using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube1.HelloNVC.Models;

namespace Sube1.HelloNVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<Ogrenci> lst = null;
            using (var ctx = new OkulDbContext())
            {
                lst =ctx.Ogrenciler.ToList();
            }
                return View(lst);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)
        {
            //nulcheck yap taghlepelrlardan yardım al httml de post ve get işlemine dikkat et
            //get student/addstudent yaoılan httpget işlemidir sayfayı getirir HttpGet yazmasa bile dafulttur 
            //modelleyerek verilerin gönderiliken (addstudent.html) post olarak gönderilir ve burda da post karşılar
            if (ogr != null)
            {
                using (var ctx=new OkulDbContext())
                {
                    ctx.Ogrenciler.Add(ogr);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditStudent(int id)
        {
            Ogrenci ogr=null;
            using (var ctx = new OkulDbContext())
            {
                ogr=ctx.Ogrenciler.Find(id);
            }
                return View(ogr);
        }

        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogr).State=EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
