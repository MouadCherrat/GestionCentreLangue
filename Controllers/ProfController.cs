using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Application_GS_ecole.Controllers
{
    public class ProfController : Controller
    {
        private readonly ProfServices profservices;

        public ProfController(ProfServices profservices)
        {
            this.profservices = profservices;
        }

        [HttpGet]
        public IActionResult AllProfs()
        {
            var profs = profservices.GetAllProfs();
            return View(profs);
        }
       
        [HttpGet]
        public IActionResult AddProf()
        {
            ViewBag.CourseList = profservices.GetCourseNames();
            return View();
        }

        [HttpPost]
        public IActionResult AddProf(Prof prof, string courseName)
        {
            Guid courseId = profservices.GetCourseIdByName(courseName);
            prof.Id_Cours = courseId;
            profservices.AddProfs(prof);
            return RedirectToAction("AllProfs");
        }
        public IActionResult Delete(Guid id)
        {
            profservices.DeleteProf(id);
            return RedirectToAction("AllProfs");
        }
    }
}
