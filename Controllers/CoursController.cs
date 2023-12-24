using Application_GS_ecole.Data;
using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
        public IActionResult AllCourses(string searchName)
        {
            var courses = coursservices.GetAllCourses();
            if (!string.IsNullOrEmpty(searchName))
            {
                courses = courses.Where(c => c.Designation.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
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

        [HttpGet]
        public IActionResult AllCoursesPDF()
        {
            var Renderer = new ChromePdfRenderer();
            var courses = coursservices.GetAllCourses();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<style>");
            stringBuilder.AppendLine("h2 { text-align: center; }");
            stringBuilder.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            stringBuilder.AppendLine("th, td { border: 1px solid #dddddd; text-align: left; padding: 8px; }");
            stringBuilder.AppendLine("th { background-color: #f2f2f2; }");
            stringBuilder.AppendLine("</style>");

            stringBuilder.AppendLine("<h2>List of Courses</h2>");
            stringBuilder.AppendLine("<table>");
            stringBuilder.AppendLine("<thead>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<th>Course designation</th>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("</thead>");
            stringBuilder.AppendLine("<tbody>");

            foreach (var cours in courses)
            {
                stringBuilder.AppendLine("<tr>");
                stringBuilder.AppendLine($"<td>{cours.Designation}</td>");
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
