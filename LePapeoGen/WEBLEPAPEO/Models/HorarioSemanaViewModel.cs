using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class HorarioSemanaViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }
        /**
        [Display(Prompt = "Horario", Description = "Horario", Name = "Horario dia")]
        [Required(ErrorMessage = "Debe indicar el horario del dia.")]
        public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> Horario_dia { get; set; }

        [Display(Prompt = "Restaurante", Description = "Restaurante", Name = "Restaurante")]
        [Required(ErrorMessage = "Debe indicar el restaurante.")]
        public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> Restaurante { get; set; }
        **/

    }
}