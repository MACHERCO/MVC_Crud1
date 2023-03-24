using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Crud1.Models.ViewModel
{
    public class UsuariosViewModel
    {
        //añadimos unos DATA annotation para hacer validaciones sobre los campos

        public int Id { get; set; }

        [Required]
        [Display(Name ="Nombre")]
        [StringLength(50)]

        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Primer Apellido")]
        public string Apellido { get; set; }

        [Range(1, 100)]
        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

    }
}