using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerNotificacionGenerica
    {
        public NotificacionGenericaViewModel ConvertENToModelUI(NotificacionGenericaEN notigeEN)
        {
            NotificacionGenericaViewModel notige = new NotificacionGenericaViewModel();
            notige.Id = notigeEN.Id;
            notige.Tipo = notigeEN.Tipo;
            notige.Texto = notigeEN.Texto;
            notige.Nombre = notigeEN.Nombre;

            return notige;


        }
        public IList<NotificacionGenericaViewModel> ConvertListENToModel(IList<NotificacionGenericaEN> notigel)
        {
            IList<NotificacionGenericaViewModel> notigeVM = new List<NotificacionGenericaViewModel>();
            foreach (NotificacionGenericaEN en in notigel)
            {
                notigeVM.Add(ConvertENToModelUI(en));
            }
            return notigeVM;
        }

    }
}