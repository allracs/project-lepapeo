using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerHorarioDia
    {
        public HorarioDiaViewModel ConvertENToModelUI(HorarioDiaEN diaEN)
        {
            HorarioDiaViewModel dia = new HorarioDiaViewModel();
            dia.id = diaEN.Id;
            dia.Hora_ini_am = (System.DateTime)diaEN.Hora_ini_am;
            dia.Hora_fin_am = (System.DateTime)diaEN.Hora_fin_am;
            dia.Hora_ini_pm = (System.DateTime)diaEN.Hora_ini_pm;
            dia.Hora_fin_pm = (System.DateTime)diaEN.Hora_fin_pm;
            dia.Dia = diaEN.Dia; 
            dia.HorarioSemana = diaEN.HorarioSemana.Id;

            return dia;
        }

        public IList<HorarioDiaViewModel> ConvertListENToModel (IList<HorarioDiaEN> dial){
            IList<HorarioDiaViewModel> diaVM = new List<HorarioDiaViewModel>();
            foreach (HorarioDiaEN en in dial)
            {
               diaVM.Add(ConvertENToModelUI(en));
            }
            return diaVM;
        }
        
    }
}