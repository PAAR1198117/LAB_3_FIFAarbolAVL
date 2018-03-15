using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Partido
    {
        [Key]

        [Required(AllowEmptyStrings = false, ErrorMessage = "El numero de partido es requerido")]
        [Display(Name = "Numero de Partido")]
        public int NoPartido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El numero de partido es requerido")]
        [Display(Name = "Fecha de Partido")]
        public DateTime Fecha { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "El grupo es requerido")]
        [StringLength(1, ErrorMessage = "El grupo debe de ser de solo una letra")]
        [Display(Name = "Grupo de Partido")]
        public string Grupo { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Local")]
        public string Pais1 { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Visitante")]
        public string Pais2 { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Estadio")]
        public string Estadio { get; set; }


    }
}