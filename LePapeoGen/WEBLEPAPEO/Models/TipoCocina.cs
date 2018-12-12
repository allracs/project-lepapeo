using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBLEPAPEO.Models
{
    public class TipoCocinaViewModel
    {
        [ScaffoldColumn(false)]
        public string Tipo { get; set; }
    }
}