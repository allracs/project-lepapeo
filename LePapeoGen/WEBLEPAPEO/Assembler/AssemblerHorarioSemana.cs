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
            sem.id = semEN.Id;
            //sem.Restaurante = semEN.Restaurante;
            //sem.Horario_dia = sem.Horario_dia;

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