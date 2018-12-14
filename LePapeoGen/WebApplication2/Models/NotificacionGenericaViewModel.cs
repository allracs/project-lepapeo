using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class NotificacionGenericaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Tipo de Notificacion para la NotificacionGenerica", Description = "Tipo de Notificacion para la NotificacionGenerica", Name = "Tipo Notificacion ")]
        [Required(ErrorMessage = "Debe indicar un tipo de notificacion para la notificacion generica")] 
        public LePapeoGenNHibernate.Enumerated.LePapeo.TipoNotificacionEnum Tipo { get; set; } 

        [Display(Prompt = "Texto para la notificacion generica", Description = "Texto para la notificacion generica", Name = "Texto ")]
        [Required(ErrorMessage = "Debe indicar un texto para la notificacion generica")]
        [StringLength(maximumLength: 3000, ErrorMessage = "El texto debe tener menos de 3000 caracteres")]
        public string Texto { get; set; }

        [Display(Prompt = "Nombre para la notificacion generica", Description = "Nombre para la notificacion generica", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la notificacion generica")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre debe tener menos de 200 caracteres")]
        public string Nombre { get; set; }
    }
}