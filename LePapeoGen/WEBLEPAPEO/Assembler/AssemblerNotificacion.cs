using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerNotificacion
    {
        public NotificacionViewModel ConvertENToModelUI(NotificacionEN notiEN)
        {
            NotificacionViewModel noti = new NotificacionViewModel();
            noti.id = notiEN.Id;
            noti.contenido = notiEN.Contenido;
            noti.fecha = notiEN.Fecha; //LePapeoGenNHibernate.Utils.Util.GetEncondeMD5(adminEN.Pass)
            noti.enviada = notiEN.Enviada;

            return noti;


        }
        public IList<NotificacionViewModel> ConvertListENToModel (IList<NotificacionEN> ens){
            IList<NotificacionViewModel> notiVM = new List<NotificacionViewModel>();
            foreach (NotificacionEN en in ens)
            {
                notiVM.Add(ConvertENToModelUI(en));
            }
            return notiVM;
        }
        
    }
}