using Application_GS_ecole.Data;
using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Application_GS_ecole.Controllers
{
    public class CoursController : Controller
    {
        private readonly CoursServices coursservices;

        public CoursController(CoursServices coursservices)
        {
            this.coursservices = coursservices;
        }

        [HttpGet]
        public IActionResult AllCourses()
        {
            var courses = coursservices.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult AddCourses() => View();

        [HttpPost]
       
        public IActionResult AddCourses(Cours cours)
        {
            coursservices.AddCours(cours);
            return RedirectToAction("AllCourses"); // Redirect to a different action
        }
   
        public IActionResult Delete(Guid id)
        {
            coursservices.DeleteCours(id);
            return RedirectToAction("AllCourses");
        }

    }

}
