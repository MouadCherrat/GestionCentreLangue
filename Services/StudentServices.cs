using Application_GS_ecole.Data;
using Application_GS_ecole.Models;
using Microsoft.EntityFrameworkCore;

namespace Application_GS_ecole.Services
{
    public class StudentServices
    {
        private readonly Mvcecolecontext _context;
        public StudentServices(Mvcecolecontext _context)
        {
            this._context = _context;

        }
        public List<Etudiant> GetAllStudent()
        {
            return _context.Etudiants.Include(g => g.cours).ToList();

        }
        public void AddStudent(Etudiant etudiant)
        {
            _context.Etudiants.Add(etudiant);
            _context.SaveChanges();
        }
        public Guid GetCourseIdByName(string courseName)
        {
            var course = _context.Cours.FirstOrDefault(c => c.Designation == courseName);
            return course.Id_cours;
        }
        public List<string> GetCourseNames()
        {
            return _context.Cours.Select(c => c.Designation).ToList();
        }
    }
}