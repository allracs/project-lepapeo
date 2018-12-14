using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBLEPAPEO.Models
{
    public class TipoCocinaViewModel
    {
        [Display(Prompt = "Tipo de cocina del restaurante", Description = "Tipo de cocina del restaurante", Name = "Tipo de cocina ")]
        [Required(ErrorMessage = "Debe indicar un tipo de cocina para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "El tipo de cocina no puede tener más de 200 caracteres")]
        public string Tipo { get; set; }
    }
}