using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
        public IActionResult AllProfs(string searchName)
        {
            var profs = profservices.GetAllProfs();
            if (!string.IsNullOrEmpty(searchName))
            {
                profs = profs.Where(p => p.Nom.Contains(searchName, StringComparison.OrdinalIgnoreCase) ||
                   p.Prenom.Contains(searchName, StringComparison.OrdinalIgnoreCase) ).ToList();
            }
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

        public IActionResult AllProfsPDF()
        {
            var Renderer = new ChromePdfRenderer();
            var profs = profservices.GetAllProfs();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<style>");
            stringBuilder.AppendLine("h2 { text-align: center; }");
            stringBuilder.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            stringBuilder.AppendLine("th, td { border: 1px solid #dddddd; text-align: left; padding: 8px; }");
            stringBuilder.AppendLine("th { background-color: #f2f2f2; }");
            stringBuilder.AppendLine("</style>");

            stringBuilder.AppendLine("<h2>List of Profs</h2>");
            stringBuilder.AppendLine("<table>");
            stringBuilder.AppendLine("<thead>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<th>Last Name</th>");
            stringBuilder.AppendLine("<th>First Name</th>");
            stringBuilder.AppendLine("<th>Course</th>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("</thead>");
            stringBuilder.AppendLine("<tbody>");

            foreach (var prof in profs)
            {
                stringBuilder.AppendLine("<tr>");
                stringBuilder.AppendLine($"<td>{prof.Nom}</td>");
                stringBuilder.AppendLine($"<td>{prof.Prenom}</td>");
                stringBuilder.AppendLine($"<td>{(prof.Cours != null ? prof.Cours.Designation : "No Course")}</td>");
                stringBuilder.AppendLine("</tr>");
            }

            stringBuilder.AppendLine("</tbody>");
            stringBuilder.AppendLine("</table>");

            using var PDF = Renderer.RenderHtmlAsPdf(stringBuilder.ToString());

            var contentLength = PDF.BinaryData.Length;

            Response.Headers["Content-Length"] = contentLength.ToString();
            Response.Headers.Add("Content-Disposition", "inline; filename=students.pdf");

            return File(PDF.BinaryData, "application/pdf");
        }
    }
}
