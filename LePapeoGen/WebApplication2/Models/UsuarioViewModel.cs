using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Email del usuario", Description = "Email del usuario", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un email para el usuario")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe proporcionar una contraseña")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Contraseña del usuario", Description = "Contraseña del usuario", Name = "Contraseña ")]
        public string Password { get; set; }

        [Display(Prompt = "Fecha de inscripción del usuario", Description = "Fecha de inscripcióndel usuario", Name = "Fecha de inscripción ")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime FechaInscripcion { get; set; }

    }
}