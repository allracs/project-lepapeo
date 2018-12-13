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
            noti.Id = notiEN.Id;
            noti.Contenido = notiEN.Contenido;
            noti.NotificacionGenerica = notiEN.NotificacionGenerica;
            noti.Fecha = (System.DateTime)notiEN.Fecha;
            noti.Enviada = notiEN.Enviada;

            return noti;
        }
        public IList<NotificacionViewModel> ConvertListENToModel(IList<NotificacionEN> notil)
        {
            IList<NotificacionViewModel> notiVM = new List<NotificacionViewModel>();
            foreach (NotificacionEN en in notil)
            {
                notiVM.Add(ConvertENToModelUI(en));
            }
            return notiVM;
        }

    }
}