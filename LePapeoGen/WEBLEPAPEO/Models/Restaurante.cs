using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBLEPAPEO.Models
{
    public class RestauranteViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Email del restaurante", Description = "Email del restaurante", Name = "Email ")]
        [Required(ErrorMessage = "Debe introducir un email para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "El email no puede tener más de 200 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Contraseña del restaurante", Description = "Contraseña del restaurante", Name = "Contraseña ")]
        [Required(ErrorMessage = "Debe indicar una contraseña para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "La contraseña no puede tener más de 200 caracteres")]
        public string Pass { get; set; }

        [Display(Prompt = "Fecha de inscripcion del restaurante", Description = "Fecha de inscripción del restaurante", Name = "Fecha de inscripción ")]
        [Required(ErrorMessage = "Debe indicar una fecha de inscripción para el restaurante")]
        public DateTime? Fecha_inscripcion { get; set; }

        [Display(Prompt = "Nombre del restaurante", Description = "Nombre del restaurante", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Fecha de apertura del restaurante", Description = "Fecha de apertura del restaurante", Name = "Fecha de apertura ")]
        [Required(ErrorMessage = "Debe indicar una fecha de apertura para el restaurante")]
        public DateTime? Fecha_apertura { get; set; }

        [Display(Prompt = "Número máximo de comensales del restaurante", Description = "Número máximo de comensales del restaurante", Name = "Número de comensales ")]
        [Required(ErrorMessage = "Debe indicar un número máximo de comensales para el restaurante")]
        public int Max_comen { get; set; }

        [Display(Prompt = "Comensales actuales del restaurante", Description = "Comensales actuales del restaurante", Name = "Comensales actuales ")]
        [Required(ErrorMessage = "Debe indicar los comensales actuales para el restaurante")]
        public int Current_comen { get; set; }

        [Display(Prompt = "Precio medio del restaurante", Description = "Precio medio del restaurante", Name = "Precio medio ")]
        [Required(ErrorMessage = "Debe indicar el precio medio del restaurante")]
        public float Precio_medio { get; set; }

        [Display(Prompt = "Descripción del restaurante", Description = "Descripción del restaurante", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripción del restaurante no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Menú del restaurante", Description = "Menú del restaurante", Name = "Menú ndel restaurante ")]
        [Required(ErrorMessage = "Debe indicar un tipo de cocina para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "El menú del restaurante no puede tener más de 200 caracteres")]
        public string Menu { get; set; }

        [Display(Prompt = "Tipo de cocina del restaurante", Description = "Tipo de cocina del restaurante", Name = "Tipo de cocina ")]
        [Required(ErrorMessage = "Debe indicar un tipo de cocina para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "El tipo de cocina no puede tener más de 200 caracteres")]
        public string Tipo { get; set; }


    }
}