

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.Exceptions;

using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;


namespace LePapeoGenNHibernate.CEN.LePapeo
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionCAD _INotificacionCAD;

public NotificacionCEN()
{
        this._INotificacionCAD = new NotificacionCAD ();
}

public NotificacionCEN(INotificacionCAD _INotificacionCAD)
{
        this._INotificacionCAD = _INotificacionCAD;
}

public INotificacionCAD get_INotificacionCAD ()
{
        return this._INotificacionCAD;
}

public int New_ (string p_contenido, int p_notificacionGenerica, Nullable<DateTime> p_fecha, bool p_enviada)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Contenido = p_contenido;


        if (p_notificacionGenerica != -1) {
                // El argumento p_notificacionGenerica -> Property notificacionGenerica es oid = false
                // Lista de oids id
                notificacionEN.NotificacionGenerica = new LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN ();
                notificacionEN.NotificacionGenerica.Id = p_notificacionGenerica;
        }

        notificacionEN.Fecha = p_fecha;

        notificacionEN.Enviada = p_enviada;

        //Call to NotificacionCAD

        oid = _INotificacionCAD.New_ (notificacionEN);
        return oid;
}

public void Modify (int p_Notificacion_OID, string p_contenido, Nullable<DateTime> p_fecha, bool p_enviada)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Contenido = p_contenido;
        notificacionEN.Fecha = p_fecha;
        notificacionEN.Enviada = p_enviada;
        //Call to NotificacionCAD

        _INotificacionCAD.Modify (notificacionEN);
}

public void Destroy (int id
                     )
{
        _INotificacionCAD.Destroy (id);
}

public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionCAD.ReadOID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionCAD.ReadAll (first, size);
        return list;
}
public void AgregarUsuario (int p_Notificacion_OID, int p_usuario_OID)
{
        //Call to NotificacionCAD

        _INotificacionCAD.AgregarUsuario (p_Notificacion_OID, p_usuario_OID);
}
public void DesvincularUsuario (int p_Notificacion_OID, int p_usuario_OID)
{
        //Call to NotificacionCAD

        _INotificacionCAD.DesvincularUsuario (p_Notificacion_OID, p_usuario_OID);
}
public void AgregarReserva (int p_Notificacion_OID, int p_reserva_OID)
{
        //Call to NotificacionCAD

        _INotificacionCAD.AgregarReserva (p_Notificacion_OID, p_reserva_OID);
}
public void DesvincularReserva (int p_Notificacion_OID, int p_reserva_OID)
{
        //Call to NotificacionCAD

        _INotificacionCAD.DesvincularReserva (p_Notificacion_OID, p_reserva_OID);
}
public void AgregarOpinion (int p_Notificacion_OID, int p_opinion_OID)
{
        //Call to NotificacionCAD

        _INotificacionCAD.AgregarOpinion (p_Notificacion_OID, p_opinion_OID);
}
public void DesvincularOpinion (int p_Notificacion_OID, int p_opinion_OID)
{
        //Call to NotificacionCAD

        _INotificacionCAD.DesvincularOpinion (p_Notificacion_OID, p_opinion_OID);
}
public LePapeoGenNHibernate.EN.LePapeo.RegistradoEN GetUsuario (int p_notificacion)
{
        return _INotificacionCAD.GetUsuario (p_notificacion);
}
public LePapeoGenNHibernate.EN.LePapeo.ReservaEN GetReserva (int p_notificacion)
{
        return _INotificacionCAD.GetReserva (p_notificacion);
}
public LePapeoGenNHibernate.EN.LePapeo.OpinionEN GetOpinion (int p_notificacion)
{
        return _INotificacionCAD.GetOpinion (p_notificacion);
}
}
}
