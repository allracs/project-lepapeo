

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
 *      Definition of the class ReservaCEN
 *
 */
public partial class ReservaCEN
{
private IReservaCAD _IReservaCAD;

public ReservaCEN()
{
        this._IReservaCAD = new ReservaCAD ();
}

public ReservaCEN(IReservaCAD _IReservaCAD)
{
        this._IReservaCAD = _IReservaCAD;
}

public IReservaCAD get_IReservaCAD ()
{
        return this._IReservaCAD;
}

public int New_ (int p_registrado, int p_restaurante, int p_comensales, LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum p_estado, bool p_finalizada, Nullable<DateTime> p_fecha_hora, Nullable<DateTime> p_fecha_solicitud)
{
        ReservaEN reservaEN = null;
        int oid;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();

        if (p_registrado != -1) {
                // El argumento p_registrado -> Property registrado es oid = false
                // Lista de oids id
                reservaEN.Registrado = new LePapeoGenNHibernate.EN.LePapeo.RegistradoEN ();
                reservaEN.Registrado.Id = p_registrado;
        }


        if (p_restaurante != -1) {
                // El argumento p_restaurante -> Property restaurante es oid = false
                // Lista de oids id
                reservaEN.Restaurante = new LePapeoGenNHibernate.EN.LePapeo.RestauranteEN ();
                reservaEN.Restaurante.Id = p_restaurante;
        }

        reservaEN.Comensales = p_comensales;

        reservaEN.Estado = p_estado;

        reservaEN.Finalizada = p_finalizada;

        reservaEN.Fecha_hora = p_fecha_hora;

        reservaEN.Fecha_solicitud = p_fecha_solicitud;

        //Call to ReservaCAD

        oid = _IReservaCAD.New_ (reservaEN);
        return oid;
}

public void Modify (int p_Reserva_OID, int p_comensales, LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum p_estado, bool p_finalizada, Nullable<DateTime> p_fecha_hora, Nullable<DateTime> p_fecha_solicitud)
{
        ReservaEN reservaEN = null;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();
        reservaEN.Id = p_Reserva_OID;
        reservaEN.Comensales = p_comensales;
        reservaEN.Estado = p_estado;
        reservaEN.Finalizada = p_finalizada;
        reservaEN.Fecha_hora = p_fecha_hora;
        reservaEN.Fecha_solicitud = p_fecha_solicitud;
        //Call to ReservaCAD

        _IReservaCAD.Modify (reservaEN);
}

public void Destroy (int id
                     )
{
        _IReservaCAD.Destroy (id);
}

public ReservaEN ReadOID (int id
                          )
{
        ReservaEN reservaEN = null;

        reservaEN = _IReservaCAD.ReadOID (id);
        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> list = null;

        list = _IReservaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistrado (int p_registrado)
{
        return _IReservaCAD.GetReservasFromRegistrado (p_registrado);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestaurante (int p_restaurante)
{
        return _IReservaCAD.GetReservasFromRestaurante (p_restaurante);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteYRegistrado (int p_registrado, int p_restaurante)
{
        return _IReservaCAD.GetReservasFromRestauranteYRegistrado (p_registrado, p_restaurante);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistradoFinal (int p_registrado, bool ? p_finalizada)
{
        return _IReservaCAD.GetReservasFromRegistradoFinal (p_registrado, p_finalizada);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteFinal (int p_restaurante, bool ? p_finalizada)
{
        return _IReservaCAD.GetReservasFromRestauranteFinal (p_restaurante, p_finalizada);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistradoByFechaHora (int p_registrado, Nullable<DateTime> p_fecha_hora)
{
        return _IReservaCAD.GetReservasFromRegistradoByFechaHora (p_registrado, p_fecha_hora);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteByFechaHora (int p_restaurante, Nullable<DateTime> p_fecha_hora)
{
        return _IReservaCAD.GetReservasFromRestauranteByFechaHora (p_restaurante, p_fecha_hora);
}
}
}
