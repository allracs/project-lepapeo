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
            noti.contenido = notiEN.Contenido;
            noti.notificacionGenerica = notiEN.NotificacionGenerica;
            noti.fecha = (System.DateTime)notiEN.Fecha;
            noti.enviada = notiEN.Enviada;

            return noti;
        }
        public IList<NotificacionViewModel> ConvertListENToModel (IList<NotificacionEN> notil){
            IList<NotificacionViewModel> notiVM = new List<NotificacionViewModel>();
            foreach (NotificacionEN en in notil)
            {
               notiVM.Add(ConvertENToModelUI(en));
            }
            return notiVM;
        }
        
    }
}