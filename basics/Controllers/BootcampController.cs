using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers
{
    public class BootcampController : Controller{
        public IActionResult Index(){

            var bootcamp = new Bootcamp();

            bootcamp.Id = 1;
            bootcamp.Title = "Backend Bootcamp";
            bootcamp.Description = "3 hafta sürecek bir bootcamp";
            bootcamp.Image = "1.jpg";
            return View(bootcamp);
        }
        public IActionResult List(){
            return View(Repository.Bootcamps);
        }

        public IActionResult Details(int? id){
            if(id == null){
                return RedirectToAction("List");
            }
            var bootcamp = Repository.GetById(id);
            return View(bootcamp);
        }
    }
} 