using System;
using Application_GS_ecole.Models;
using Application_GS_ecole.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Application_GS_ecole.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminServices _adminServices;

        public AdminController(AdminServices adminServices)
        {
            _adminServices = adminServices;
        }
        [HttpGet]
        public IActionResult AllAdmins()
        {
            var admins = _adminServices.GetAllAdmins();
            return View(admins);
        }
        [HttpGet]
        public IActionResult AddAdmins()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdmins(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _adminServices.AddAdmin(admin);
                return RedirectToAction("AllAdmins");
            }
            return View(admin);
        }
        [HttpPost]
        public IActionResult DeleteAdmins(Guid adminId)
        {
            _adminServices.DeleteAdmin(adminId);
            return RedirectToAction("AllAdmins");
        }

    }
}
