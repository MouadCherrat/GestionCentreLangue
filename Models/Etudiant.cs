using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Application_GS_ecole.Models
{
    public class Etudiant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Etudiant { get; set; }

        [Required(ErrorMessage = "donner le nom")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "donner le prenom")]
        [StringLength(50)]
        public string Prenom { get; set; }

        public Guid Id_Groupe { get; set; }
        public double Note1 { get; set; }
        public double Note2 { get; set; }
      //  public string Admission => Note1 / Note2 >= 10 ? "Admis" : "Non Admis";
    }
}