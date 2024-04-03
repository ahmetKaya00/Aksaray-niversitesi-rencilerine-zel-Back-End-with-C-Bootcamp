using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class BootcampController : Controller{
        private readonly DataContext _context;

        public BootcampController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            return View(await _context.Bootcamps.Include(x=>x.Egitmen).ToListAsync());
        }

        public async Task<IActionResult> Create(){
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(),"EgitmenId","AdSoyad");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Bootcamp model){

            _context.Bootcamps.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

         [HttpGet]
        public async Task<IActionResult>Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var bootcamp = 
            await _context.Bootcamps
                            .Include(o=>o.BootcampKayit)
                            .ThenInclude(x=>x.Ogrenci)
                            .FirstOrDefaultAsync(b=>b.BootcampId == id);
            if(bootcamp == null){
                return NotFound();
            }
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(),"EgitmenId","AdSoyad");
            return View(bootcamp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, Bootcamp model){
            if(id != model.BootcampId){
                return NotFound();
            }

            if(ModelState.IsValid){
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Bootcamps.Any(o=>o.BootcampId == model.BootcampId)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(),"EgitmenId","AdSoyad");
            return View(model);
        }

            [HttpGet]
            public async Task<IActionResult>Delete(int? id){
                if(id == null){
                    return NotFound();
                }
                var bootcamp = await _context.Bootcamps.FindAsync(id);

                if(bootcamp == null){
                    return NotFound();
                }
                return View(bootcamp);
            }

            [HttpPost]
            public async Task<IActionResult>Delete([FromForm]int id){
                var bootcamp = await _context.Bootcamps.FindAsync(id);
                if(bootcamp == null){
                    return NotFound();
                }
                _context.Bootcamps.Remove(bootcamp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
    }
}