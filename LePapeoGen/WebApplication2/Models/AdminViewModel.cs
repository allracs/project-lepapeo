using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class AdminViewModel
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
        public DateTime? FechaInscripcion { get; set; }


        /*
        [ScaffoldColumn(false)]
        public string NombreCategoria { get; set; }


        [Display(Prompt = "Nombre del artículo", Description = "Nombre del artículo", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Descripción del artículo", Description = "Descripción del artículo", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }


        [Display(Prompt = "Imagen del artículo", Description = "Unidades del artículo", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public string Imagen { get; set; }
        */

    }
}