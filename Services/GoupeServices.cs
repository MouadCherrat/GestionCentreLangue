using Application_GS_ecole.Data;
using Application_GS_ecole.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Application_GS_ecole.Services
{
    public class GroupeServices
    {
        private readonly Mvcecolecontext _context;
        public GroupeServices(Mvcecolecontext _context)
        {
            this._context = _context;

        }
        public List<Groupe> GetAllGroup()
        {
            return _context.Groupes.Include(g => g.Cours).ToList();

        }
        public void AddGroupes(Groupe group)
        {
            _context.Groupes.Add(group);
            _context.SaveChanges();
        }
        public Guid GetCourseIdByName(string courseName)
        {
            var course = _context.Cours.FirstOrDefault(c => c.Designation == courseName);
                return course.Id_cours;   
        }


    }
}