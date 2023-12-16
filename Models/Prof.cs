using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Application_GS_ecole.Models
{
    public class Prof
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Prof { get; set; }

        [Required(ErrorMessage = "donner le nom")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "donner le prenom")]
        [StringLength(50)]
        public string Prenom { get; set; }
        public Guid Id_Cours { get; set; }
    }
}
