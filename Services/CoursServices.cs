using Application_GS_ecole.Data;
using Application_GS_ecole.Models;

namespace Application_GS_ecole.Services
{
    public class CoursServices
    {
        private readonly Mvcecolecontext _context; //used to declare a field that can only be assigned a value at the time of declaration 

        public CoursServices(Mvcecolecontext _context)
        {
            this._context = _context;
        }

        public List<Cours> GetAllCourses()
        {
            return _context.Cours.ToList();
        }

        public void AddCours(Cours cours)
        {
            _context.Cours.Add(cours);  
            _context.SaveChanges();
        }
        public void DeleteCours(Guid courseId)
        {
            var courseToDelete = _context.Cours.Find(courseId);

            if (courseToDelete != null)
            {
                _context.Cours.Remove(courseToDelete);
                _context.SaveChanges();
            }
        }

  
       
    }
}
