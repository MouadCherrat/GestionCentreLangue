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
        [Route("Cours/AllCourses")]

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
        [HttpPost]
        public IActionResult DeleteCourse(Guid courseId)
        {
            coursservices.DeleteCours(courseId);
            return RedirectToAction("AllCourses");
        }

        [HttpGet]
        public IActionResult EditCourse(Guid courseId)
        {
            var course = coursservices.GetCoursById(courseId);
            return View(course);
        }

        [HttpPost]
        public IActionResult EditCourse(Cours cours)
        {
          
                coursservices.EditCourse(cours);
                return RedirectToAction("AllCourses");
        

        }

    }

}
