using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Contenido para la notificacion", Description = "Contenido para la notificacion", Name = "Contenido ")]
        [Required(ErrorMessage = "Debe indicar un contenido para la notificacion")]
        [StringLength(maximumLength: 3000, ErrorMessage = "El contenido debe tener maximo 3000 caracteres")]
        public string Contenido { get; set; }

        [Display(Prompt = "NotificacionGenerica para la Notificacion", Description = "NotificacionGenerica para la Notificacion", Name = "NotificacionGenerica ")]
        [Required(ErrorMessage = "Debe indicar una Notificacion Generica para la Notificacion")]
        public LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN NotificacionGenerica { get; set; }

        [Display(Prompt = "Fecha para la Notificacion", Description = "Fecha para la Notificacion", Name = "Fecha de la Notificacion ")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime Fecha { get; set; }

        [Display(Prompt = "Indicador de envio", Description = "Indicador de envio", Name = "Indicador de envio ")]
        [Required(ErrorMessage = "Debe indicar un indicador de envio")]
        public Boolean Enviada { get; set; }
    }
}