using Application_GS_ecole.Data;
using Application_GS_ecole.Models;
using Microsoft.EntityFrameworkCore;

namespace Application_GS_ecole.Services
{
    public class ProfServices
    {
        private readonly Mvcecolecontext _context;
        public ProfServices(Mvcecolecontext _context)
        {
            this._context = _context;

        }
        public List<Prof> GetAllProfs()
        {
            return _context.Profs.Include(g => g.Cours).ToList();

        }
        public void AddProfs(Prof prof)
        {
            _context.Profs.Add(prof);
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
        public void DeleteProf(Guid profId)
        {
            var prof = _context.Profs.Find(profId);
            _context.Profs.Remove(prof);
            _context.SaveChanges();
        }
    }
}
