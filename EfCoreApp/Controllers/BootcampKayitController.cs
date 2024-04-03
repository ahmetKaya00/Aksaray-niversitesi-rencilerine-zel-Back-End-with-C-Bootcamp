using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class BootcampKayitController : Controller{
        private readonly DataContext _context;

        public BootcampKayitController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            var bootcampkayitlari = await _context.Kayitlar.Include(x=>x.Ogrenci).Include(x=>x.Bootcamp).ToListAsync();
            return View(bootcampkayitlari);
        }

        public async Task<IActionResult>Create(){
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(),"OgrenciId","AdSoyad");
            ViewBag.Bootcamps = new SelectList(await _context.Bootcamps.ToListAsync(),"BootcampId","Baslik");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(BootcampKayit model){

            model.KayitTarihi = DateTime.Now;
            _context.Kayitlar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}