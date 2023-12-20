using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application_GS_ecole.Controllers
{
    public class GroupeController : Controller
    {
        private readonly GroupeServices groupeservices;

        public GroupeController(GroupeServices groupeservices)
        {
            this.groupeservices = groupeservices;
        }

        [HttpGet]
        public IActionResult AllGroupes()
        {
            var groupes = groupeservices.GetAllGroup();
            return View(groupes);
        }
        [HttpGet]
        public IActionResult AddGroupes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGroupes(Groupe group, string courseName)
        {
            Guid courseId = groupeservices.GetCourseIdByName(courseName);
            group.Id_Cours = courseId;
            groupeservices.AddGroupes(group);
            return RedirectToAction("AllGroupes");
        }

    }


}