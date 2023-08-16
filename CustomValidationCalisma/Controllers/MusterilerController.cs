using CustomValidationCalisma.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomValidationCalisma.Controllers
{
    public class MusterilerController : Controller

    {
        static readonly List<Musteri> musteriler = new() { 
        
        new Musteri{Ad="Ahmet", DogumTarihi = new DateTime(1980,1,1)},
        new Musteri{Ad="Mehmet", DogumTarihi = new DateTime(1985,1,1)},
        new Musteri{Ad="Ayse", DogumTarihi = new DateTime(1990,1,1)},
        new Musteri{Ad="Fatma", DogumTarihi = new DateTime(1995,1,1)},
        
        };
        public IActionResult Index( string? sonuc)
        {
            ViewBag.Mesaj = MesajaKararVer(sonuc); // sonuc null ise bos string ata
            return View(musteriler);
        }

        private dynamic MesajaKararVer(string? sonuc)
        {
            switch (sonuc)
            {
                case "eklendi":
                    return "Yeni musteri eklendi";
                case "guncellendi":
                    return "Musteri bilgileri guncellendi";
                case "silindi":
                    return "Musteri silindi";
                default:
                    return "";
            }
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(Musteri musteri)
        {

            if (ModelState.IsValid)
            {
                musteriler.Add(musteri);
                return RedirectToAction(nameof(Index), new {sonuc = "eklendi" }); // methodun adini string olarak veriyoruz
            }
            return View();
        }

    }
}
