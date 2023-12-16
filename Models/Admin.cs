using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Application_GS_ecole.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Admin { get; set; }

        [Required(ErrorMessage = "donner le login")]
        [StringLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "donner le mot de passe")]
        [StringLength(50)]
        public string MotDePasse { get; set; }
    }
}
