using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class ReservaViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Número de comensales", Description = "Número de comensales", Name = "Comensales")]
        [Required(ErrorMessage = "Debe indicar un número de comensales")]
        public int comensales { get; set; }

        [Display(Prompt = "Estado de la reserva", Description = "Estado de la reserva (pendiente, aceptado, denegado)", Name = "Estado")]
        [Required(ErrorMessage = "No debería de dar error, como default se pone estado pendiente")]
        public IList<int> estado { get; set; }

        [Display(Prompt = "Reserva finalizada o no", Description = "En forma booleana muestra si la fecha de la reserva es anterior o posterior a fecha actual", Name = "Finalizada")]
        [Required(ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public bool finalizada { get; set; }

        [Display(Prompt = "Fecha para la que se solicita la reserva", Description = "Fecha para la que se solicita la reserva, cuando quieren asistir los comensales", Name = "Fecha_hora")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime fecha_hora { get; set; }

        [Display(Prompt = "Fecha de solicitud", Description = "Fecha en la que se solicita la reserva", Name = "Fecha solicitud")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime fecha_solicitud { get; set; }
    }
}