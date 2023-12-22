using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application_GS_ecole.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentServices studentservices;

        public StudentController(StudentServices studentservices)
        {
            this.studentservices = studentservices;
        }

       [HttpGet]
        public IActionResult AllStudents()
        {
            var student = studentservices.GetAllStudent();
            return View(student);
        } 
        [HttpGet]
        public IActionResult AddStudent()
        {
            ViewBag.CourseList = studentservices.GetCourseNames();
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Etudiant etudiant, string courseName)
        {
            Guid courseId = studentservices.GetCourseIdByName(courseName);
            etudiant.Id_Cours = courseId;
            studentservices.AddStudent(etudiant);
            return RedirectToAction("AllStudents");
        }
    }
}
