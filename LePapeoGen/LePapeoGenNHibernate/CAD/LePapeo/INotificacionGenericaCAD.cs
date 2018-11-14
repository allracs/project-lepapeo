
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface INotificacionGenericaCAD
{
NotificacionGenericaEN ReadOIDDefault (int id
                                       );

void ModifyDefault (NotificacionGenericaEN notificacionGenerica);

System.Collections.Generic.IList<NotificacionGenericaEN> ReadAllDefault (int first, int size);



int New_ (NotificacionGenericaEN notificacionGenerica);

void Modify (NotificacionGenericaEN notificacionGenerica);


void Destroy (int id
              );
}
}
