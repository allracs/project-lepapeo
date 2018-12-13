using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerReserva
    {
        public ReservaViewModel ConvertENToModelUI(ReservaEN resEN)
        {
            ReservaViewModel res = new ReservaViewModel();
            res.id = resEN.Id;
            res.idusuario = resEN.Registrado.Id;
            res.idrestaurante = resEN.Restaurante.Id;
            res.comensales = resEN.Comensales;
            res.estado = resEN.Estado;
            res.finalizada = resEN.Finalizada;
            res.fecha_hora = (DateTime) resEN.Fecha_hora;
            res.fecha_solicitud = (DateTime) resEN.Fecha_solicitud;
            
            return res;
        }
        public IList<ReservaViewModel> ConvertListENToModel (IList<ReservaEN> resL){
            IList<ReservaViewModel> reslist = new List<ReservaViewModel>();
            foreach (ReservaEN res in resL)
            {
                reslist.Add(ConvertENToModelUI(res));
            }
            return reslist;
        }
        
    }
}