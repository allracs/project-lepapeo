using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerOpinion
    {
        public OpinionViewModel ConvertENToModelUI(OpinionEN opiEN)
        {
            OpinionViewModel opi = new OpinionViewModel();
            opi.id = opiEN.Id;
            opi.Valoracion = opiEN.Valoracion;
            opi.Titulo = opiEN.Titulo;
            opi.Comentario = opiEN.Comentario;
            opi.Fecha = (System.DateTime)opiEN.Fecha;
            opi.Registrado = opiEN.Registrado.Id;
            opi.Restaurante = opiEN.Restaurante.Id;

            return opi;


        }
        public IList<OpinionViewModel> ConvertListENToModel (IList<OpinionEN> opi){
            IList<OpinionViewModel> opiVM = new List<OpinionViewModel>();
            foreach (OpinionEN en in opi)
            {
                opiVM.Add(ConvertENToModelUI(en));
            }
            return opiVM;
        }
        
    }
}