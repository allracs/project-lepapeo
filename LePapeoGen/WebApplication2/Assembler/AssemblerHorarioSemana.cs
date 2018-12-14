using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerHorarioSemana
    {
        public HorarioSemanaViewModel ConvertENToModelUI(HorarioSemanaEN semEN)
        {
            HorarioSemanaViewModel sem = new HorarioSemanaViewModel();
            sem.Id = semEN.Id;

            return sem;
        }

        public IList<HorarioSemanaViewModel> ConvertListENToModel (IList<HorarioSemanaEN> seml){
            IList<HorarioSemanaViewModel> semVM = new List<HorarioSemanaViewModel>();
            foreach (HorarioSemanaEN en in seml)
            {
               semVM.Add(ConvertENToModelUI(en));
            }
            return semVM;
        }
        
    }
}