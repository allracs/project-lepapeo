using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeoGenNHibernate.EN.LePapeo;
using WEBLEPAPEO.Models;

namespace WEBLEPAPEO.Models
{
    public class AssemblerTipoCocina
    {
        public TipoCocinaViewModel ConvertENToModelUI(TipoCocinaEN en)
        {
            TipoCocinaViewModel tip = new TipoCocinaViewModel();
            tip.Tipo = en.Tipo;
            return tip;
        }

        public IList<TipoCocinaViewModel> ConvertListENToModel(IList<TipoCocinaEN> tip)
        {
            IList<TipoCocinaViewModel> tips = new List<TipoCocinaViewModel>();
            foreach (TipoCocinaEN en in tip)
            {
                tips.Add(ConvertENToModelUI(en));
            }
            return tips;
        }
    }
}