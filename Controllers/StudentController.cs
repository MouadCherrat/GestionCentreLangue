using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Mvc;
using DinkToPdf.Contracts;
using IronPdf;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text;



namespace Application_GS_ecole.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentServices studentservices;
        private readonly IConverter _converter;
        private readonly ICompositeViewEngine _viewEngine;

        public StudentController(StudentServices studentservices, IConverter converter, ICompositeViewEngine viewEngine)
        {
            this.studentservices = studentservices;
            this._converter = converter;
            this._viewEngine = viewEngine;
        }

        [HttpGet]
        public IActionResult AllStudents(string searchName)
        {
            var students = studentservices.GetAllStudent();

            if (!string.IsNullOrEmpty(searchName))
            {
                students = students.Where(s =>
                    s.Nom.Contains(searchName, StringComparison.OrdinalIgnoreCase) ||
                    s.Prenom.Contains(searchName, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return View(students);
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

        public IActionResult Delete(Guid id)
        {
            studentservices.DeleteStudent(id);
            return RedirectToAction("AllStudents");
        }

        [HttpGet]
        public IActionResult List(Guid idCours)
        {
            var students = studentservices.GetStudentsByCourseId(idCours);
            var model = new List<Etudiant>(students);
            return View(model);
        }

        [HttpGet]
        public IActionResult AllStudentsPDF()
        {
            var Renderer = new ChromePdfRenderer();
            var students = studentservices.GetAllStudent();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<style>");
            stringBuilder.AppendLine("h2 { text-align: center; }");
            stringBuilder.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            stringBuilder.AppendLine("th, td { border: 1px solid #dddddd; text-align: left; padding: 8px; }");
            stringBuilder.AppendLine("th { background-color: #f2f2f2; }");
            stringBuilder.AppendLine("</style>");

            stringBuilder.AppendLine("<h2>List of students</h2>");
            stringBuilder.AppendLine("<table>");
            stringBuilder.AppendLine("<thead>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<th>Last Name</th>");
            stringBuilder.AppendLine("<th>First Name</th>");
            stringBuilder.AppendLine("<th>Course</th>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("</thead>");
            stringBuilder.AppendLine("<tbody>");

            foreach (var student in students)
            {
                stringBuilder.AppendLine("<tr>");
                stringBuilder.AppendLine($"<td>{student.Nom}</td>");
                stringBuilder.AppendLine($"<td>{student.Prenom}</td>");
                stringBuilder.AppendLine($"<td>{(student.cours != null ? student.cours.Designation : "No Course")}</td>");
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
