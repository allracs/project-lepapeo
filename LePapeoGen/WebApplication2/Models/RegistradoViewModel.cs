using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class RegistradoViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Email del registrado", Description = "Email del registrado", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un email para el registrado")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe proporcionar una contraseña")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Contraseña del registrado", Description = "Contraseña del registrado", Name = "Contraseña ")]
        public string Password { get; set; }

        [Display(Prompt = "Fecha de inscripción del registrado", Description = "Fecha de inscripción del registrado", Name = "Fecha de inscripción ")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime FechaInscripcion { get; set; }



        [Display(Prompt = "Nombre del registrado", Description = "Nombre del registrado", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el regitrado")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }


        [Display(Prompt = "Apellidos del registrado", Description = "Apellidos del registrado", Name = "Apellidos ")]
        [Required(ErrorMessage = "Debe indicar unos apellidos para el regitrado")]
        [StringLength(maximumLength: 200, ErrorMessage = "Los apellidos no pueden tener más de 200 caracteres")]
        public string Apellidos { get; set; }



        [Display(Prompt = "Fecha del nacimiento del registrado", Description = "Fecha del nacimiento del registrado", Name = "Fecha del nacimiento ")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime Fecha_nacimiento { get; set; }


    }
}