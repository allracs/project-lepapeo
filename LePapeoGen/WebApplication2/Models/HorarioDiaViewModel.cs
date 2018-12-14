using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class HorarioDiaViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Fecha de apertura por la mañana", Description = "Fecha de apertura por la mañana", Name = "Fecha de apertura am")] 
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime Hora_ini_am { get; set; } 

        [Display(Prompt = "Fecha de cierre por la mañana", Description = "Fecha de cierre por la mañana", Name = "Fecha de cierre am")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime Hora_fin_am { get; set; }

        [Display(Prompt = "Fecha de apertura por la tarde", Description = "Fecha de apertura por la tarde", Name = "Fecha de apertura pm")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime Hora_ini_pm { get; set; }

        [Display(Prompt = "Fecha de cierre por la tarde", Description = "Fecha de cierre por la tarde", Name = "Fecha de cierre pm")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime Hora_fin_pm { get; set; }

        [Display(Prompt = "Dia de la semana", Description = "Dia de la semana", Name = "Dia")]
        [Required(ErrorMessage = "Debe indicar un dia para el horario semana")]
        public LePapeoGenNHibernate.Enumerated.LePapeo.DiaSemanaEnum Dia { get; set; }

        [Display(Prompt = "Horario de la semana", Description = "Horario de la semana", Name = "Semana ")]
        [Required(ErrorMessage = "Debe indicar un HorarioSemana para el HorarioDia")]
        public int HorarioSemana { get; set; } 


    }
}