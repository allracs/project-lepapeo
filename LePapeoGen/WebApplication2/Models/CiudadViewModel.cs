using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class CiudadViewModel
    {
        [Display(Prompt = "Ciudad", Description = "Ciudad", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar una ciudad")]
        public String id { get; set; }

        [Display(Prompt = "Provincia", Description = "Provincia", Name = "Provincia")]
        [Required(ErrorMessage = "Debe indicar una provincia")]
        public String provincia { get; set; }

        [Display(Prompt = "Ciudad", Description = "Ciudad", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar una ciudad")]
        public List<int> direcciones { get; set; }

    }
}