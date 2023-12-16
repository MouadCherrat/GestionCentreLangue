using Application_GS_ecole.Data;
using Application_GS_ecole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application_GS_ecole.Services
{
    public class AdminServices
    {
        private readonly Mvcecolecontext _context;

        public AdminServices(Mvcecolecontext context)
        {
            _context = context;
        }

        public List<Admin> GetAllAdmins()
        {
            return _context.Admins.ToList();
        }

        public Admin GetAdminById(Guid adminId)
        {
            return _context.Admins.Find(adminId);
        }

        public void AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }
        public void DeleteAdmin(Guid adminId)
        {
            var adminToDelete = _context.Admins.Find(adminId);

            if (adminToDelete != null)
            {
                _context.Admins.Remove(adminToDelete);
                _context.SaveChanges();
            }
        }

    }
}
