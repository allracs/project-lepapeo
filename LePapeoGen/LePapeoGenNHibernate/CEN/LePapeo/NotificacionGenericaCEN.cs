

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
 *      Definition of the class NotificacionGenericaCEN
 *
 */
public partial class NotificacionGenericaCEN
{
private INotificacionGenericaCAD _INotificacionGenericaCAD;

public NotificacionGenericaCEN()
{
        this._INotificacionGenericaCAD = new NotificacionGenericaCAD ();
}

public NotificacionGenericaCEN(INotificacionGenericaCAD _INotificacionGenericaCAD)
{
        this._INotificacionGenericaCAD = _INotificacionGenericaCAD;
}

public INotificacionGenericaCAD get_INotificacionGenericaCAD ()
{
        return this._INotificacionGenericaCAD;
}

public int New_ (LePapeoGenNHibernate.Enumerated.LePapeo.TipoNotificacionEnum p_tipo, string p_texto, string p_nombre)
{
        NotificacionGenericaEN notificacionGenericaEN = null;
        int oid;

        //Initialized NotificacionGenericaEN
        notificacionGenericaEN = new NotificacionGenericaEN ();
        notificacionGenericaEN.Tipo = p_tipo;

        notificacionGenericaEN.Texto = p_texto;

        notificacionGenericaEN.Nombre = p_nombre;

        //Call to NotificacionGenericaCAD

        oid = _INotificacionGenericaCAD.New_ (notificacionGenericaEN);
        return oid;
}

public void Modify (int p_NotificacionGenerica_OID, LePapeoGenNHibernate.Enumerated.LePapeo.TipoNotificacionEnum p_tipo, string p_texto, string p_nombre)
{
        NotificacionGenericaEN notificacionGenericaEN = null;

        //Initialized NotificacionGenericaEN
        notificacionGenericaEN = new NotificacionGenericaEN ();
        notificacionGenericaEN.Id = p_NotificacionGenerica_OID;
        notificacionGenericaEN.Tipo = p_tipo;
        notificacionGenericaEN.Texto = p_texto;
        notificacionGenericaEN.Nombre = p_nombre;
        //Call to NotificacionGenericaCAD

        _INotificacionGenericaCAD.Modify (notificacionGenericaEN);
}

public void Destroy (int id
                     )
{
        _INotificacionGenericaCAD.Destroy (id);
}
}
}
