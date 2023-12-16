using Application_GS_ecole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Application_GS_ecole.Data
{
    public class Mvcecolecontext : DbContext // dbcontext responsable de la coordination des opérations avec la base de données
    {
        public Mvcecolecontext(DbContextOptions<Mvcecolecontext> options) : base(options) //constructeur de la classe
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Prof> Profs { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
    }
}

