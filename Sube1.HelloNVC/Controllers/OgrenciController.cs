using Microsoft.AspNetCore.Mvc;
using Sube1.HelloNVC.Models;
using Sube1.HelloNVC.Models.ViewModels;

namespace Sube1.HelloNVC.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()//action metod
        {
            return View();
        }

        public ViewResult OgrenciDetay(int id)
        {
            Ogrenci ogr = null;
            Ogretmen ogrt = null;
           //Ders ders = new Ders { Dersad = "matematik", Dersid = 1,Kredi=5 };
            if (id == 1)
            {
                ogr = new Ogrenci{ Ad="Ali", Soyad="Veli", Numara=123};
            }
            else if (id == 2)
            {
                ogr = new Ogrenci{ Ad = "Ahmet", Soyad = "Mehmet", Numara = 123};
            }
            ViewData["ogrenci"]= ogr;
            ViewBag.student = ogr;//yapı farklı olsa bile aynı key i kullanamam

            if (id == 1)
            {
                ogrt = new Ogretmen { Ogretmenid = 789,Ad="denem1", Soyad="deneme2" };
            }
            else if (id == 2)
            {
                ogrt = new Ogretmen { Ogretmenid = 456, Ad = "anıl", Soyad = "güler" };
            }
            ViewBag.teacher = ogrt;

            OgrViewModel vm = new OgrViewModel();
            vm.Ogretmen = ogrt;
            vm.Ogrenci = ogr;
            vm.Ders = new Ders { Dersad = "ProgTem", Dersid = 1, Kredi = 5 };

            return View(vm);

        }
        public ViewResult OgrenciListe()
        {
            var lst = new List<Ogrenci>();
            lst.Add(new Ogrenci { Ad = "Ali", Soyad = "Veli", Numara = 123 });
            lst.Add(new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 });

            return View(lst);
        }


    }
}
//IIS: Internet Information Services 
//ISS Express 
//Render: ISS tarafından derlenip yorumlanan kodların tarayıcının anlayacağı dile çevrilmesi işlemi
//Controller'dan view'me veri taşıma yöntemleri
//actionlar metodlardır ve işlemler yapmamızı sağlarlar
//ViewData: koleksiyon yapısıdır. Ddictonary türünde koleksiyonlardır object tipinde veri tutar bu yüzden castig yapılması gerekir
//dictionary yaoıları key-value pair'lerinden oluşur 
//keyler tekil olmalıdır 
//keyler string value'lar object türündedir
//view eklemek için sağ tıklayıp razor view ekleriz
//ViewBag: ViewData üstüne geliştirimiş bir yapıdır. Arka planda ViewData koleksiyonunu kullanır dinamic bir yapıdır işlemler çalışma anında yapılır intelsense desteği yok runtime sırasında doğrudan tip tespiti yapılır bu yüzden casting yapılmaz
//viewmodel: view'e gönderilen object controller da karşılanmalıdır @model diyerek karşılanır @Model. diyerek gönderilen bilgileri alıp kullanabiliriz
//typesafedir  her view'in tek bir modeli olabilir bu sorun için viewmodels kalsörü oluşturup içine ogrviewmodel class'ı oluşturduk bu sayede 3 entity'i tek seferde gönderbiliriz bunu için ogrviewmodel tpinde nesnde türettik daha sonra vm.ogretmen diyip önceden tanımlanan öğretmne nesnesini attık daha sonra return View(vm) yaparak göndeirirz detay içinde de @model ogrviewmodel deriz ulaşmak içinde @Model.Ders.Dersad şeklinde ulaşabiliriz
//aynı işlemli viewbag ile yapmaya çalışırsak 3 tane viewbag oluşturulması gerekir intelsense yok sınav sorusu?
//viewimports dosyasında eklenen classlar tüm viewler de kullanılabilir olur sürekli using kullanmamıza gerek kalmaz 


//layout views - shared klasörleri içersinde bulunur _Layout.cshtml
//~ işareti kök dizin anlamına gelir bir mvc uygulamasının kök dizini wwwroot'tur relative path'tir
//absolute path C:\Users\USER\Desktop\Üni\2.sınıf Bahar Dönemi\Sanallaştırma\vize gibi bir yoldur web uygulamalrında mutlak path kullanılmaz
//boostrapmin.css minified küçültülmüş anlamına gelir dosya boyutunu azaltmak için kullanılır sunucu da daha az yer kaplar daha hızlıdır server ve kullnıcı arasında transfer edilmesi gereken veri daha azdır
// ../ bi üst klasör anlamına gelir
//@RenderBody() metodu layout sayfası içerinsde göstereceğimiz içerikleri getirir
//Index.cshtml gibi dosyalar da bootsrap linkleri header gibi şeyler olmaz sadece ana içerik gösterilir gerekli head footerlar _Layout'tan gelir
//bir dosyanın üstünde razor işaretleri içersinde Layout=null; yazmıyorsa o dosya layout kullanıyor demektir
//eğer layout propertsy'nin karşısında hiçbir değer yoksa default olarak mvc deki bütün sayfalar _Layout.cshtml'yi kullanr bu shared klasörü içindeki _ViewStart içerisinde belirlenir
//kendi layoutumuzu yazıp kullanmasını sağlayabiliriz tek bir layout olmasına gerek yok üst tarafta belirtmemiz gerekir kendi layoutmuzu
//layout kullanan bir view eklemek için controller da view ekleyeceğimiz metod içinde sağ tık yapıp add view deriz razor view'ı seçeriz ve en altta layout seçeneğini seçeriz boş bırakırsak ViewStart'ta bulunan _Layout'u uygular
//layout'ta head gibi etiketler bulunmaycağı için seo için etiketler yazılırken ViewData kullanılır view de kullanılan ViewData'da ki veriler _Layout içerisinde bulunan ViewData'ya gönderilir bu şekilde her sayfa için ayrı title yazılabilir
//_Layout da kendi linkimizi eklerken /Ogrenci/OgrenciList şu şekilde baştaki / önemlidir olmazsa hata oluşur ilk başta çalışır ama başka sayfaya geçildiğinde ordaki adres silinmez ve 404 alırız / başta olursa sunucu adresine kadar in localhost:5269 gibi daha sonra / la devam et kendi requestini ekle
//@Html html helpelarıdır ve c# ile html yazmadan html işlemleri yapmamızı sağlarlar mesela link vermek için a href yerine actionlink kullanılır 
// yukarıda yazıldığında css clasları etkili olmaz o yüzden null, new { @class = "nav-link text-dark" } şeklinde ekleme yapılır action link'e null routevalue için olmadığı için null yazdık new diyerek anonim bir tip oluşturduk ve içine classları yazdık
//ahref ile yapılan yöntem de render olmaz ama @Html yöntemi ile yapılan da render olur
// at helperları asp-action şeklinde yazılır hibrit bir yapıdır hem html hem c# yazılır