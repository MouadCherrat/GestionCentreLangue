using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Application_GS_ecole.Models
{
    public class Groupe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Groupe { get; set; }
        public int NumeroDeGroupe { get; set; }
        public Guid Id_Cours { get; set; }
        [ForeignKey("Id_Cours")]
        public required Cours Cours { get; set; }
    }
}
