
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface INotificacionCAD
{
NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int New_ (NotificacionEN notificacion);

void Modify (NotificacionEN notificacion);


void Destroy (int id
              );


NotificacionEN ReadOID (int id
                        );


System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size);


void AgregarUsuario (int p_Notificacion_OID, int p_usuario_OID);

void DesvincularUsuario (int p_Notificacion_OID, int p_usuario_OID);

void AgregarReserva (int p_Notificacion_OID, int p_reserva_OID);

void DesvincularReserva (int p_Notificacion_OID, int p_reserva_OID);

void AgregarOpinion (int p_Notificacion_OID, int p_opinion_OID);

void DesvincularOpinion (int p_Notificacion_OID, int p_opinion_OID);

LePapeoGenNHibernate.EN.LePapeo.RegistradoEN GetUsuario (int p_notificacion);


LePapeoGenNHibernate.EN.LePapeo.ReservaEN GetReserva (int p_notificacion);


LePapeoGenNHibernate.EN.LePapeo.OpinionEN GetOpinion (int p_notificacion);
}
}
