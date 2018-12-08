using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LePapeo.Models
{
    public class OpinionViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Valoracion", Description = "Valoracion", Name = "Valoracion ")]
        [Required(ErrorMessage = "Debe indicar una valoracion para el usuario")]
        public LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum Valoracion { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un titulo")]
        //[DataType(DataType.Password)]
        [Display(Prompt = "Titulo de la opinion", Description = "Titulo de la opinion", Name = "Titulo ")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un comentario")]
        //[DataType(DataType.Password)]
        [Display(Prompt = "Comentario de la opinion", Description = "Comentario de la opinion", Name = "Comentario ")]
        public string Comentario { get; set; }

        [Display(Prompt = "Fecha de la opinion", Description = "Fecha de la opinion", Name = "Fecha ")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida debe tener un formato dd/mm/aaaa")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un usuario registrado")]
        //[DataType(DataType.Password)]
        [Display(Prompt = "Autor de la opinion", Description = "Autor de la opinion", Name = "Registrado ")]
        public int Registrado { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un restaurante")]
        //[DataType(DataType.Password)]
        [Display(Prompt = "Objeto de la opinion", Description = "Objeto de la opinion", Name = "Restaurante ")]
        public int Restaurante { get; set; }

    }
}