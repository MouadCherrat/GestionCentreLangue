using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Application_GS_ecole.Models
{
    public class Cours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_cours { get; set; }

        [Required(ErrorMessage = "donner la disigantion")]
        [StringLength(50)]
        public required string Designation { get; set; }
    }
}
