
using System;
// Definición clase ReservaEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class ReservaEN
{
/**
 *	Atributo registrado
 */
private LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registrado;



/**
 *	Atributo restaurante
 */
private LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comensales
 */
private int comensales;



/**
 *	Atributo estado
 */
private LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum estado;



/**
 *	Atributo finalizada
 */
private bool finalizada;



/**
 *	Atributo fecha_hora
 */
private Nullable<DateTime> fecha_hora;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion;



/**
 *	Atributo fecha_solicitud
 */
private Nullable<DateTime> fecha_solicitud;






public virtual LePapeoGenNHibernate.EN.LePapeo.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.RestauranteEN Restaurante {
        get { return restaurante; } set { restaurante = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Comensales {
        get { return comensales; } set { comensales = value;  }
}



public virtual LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual bool Finalizada {
        get { return finalizada; } set { finalizada = value;  }
}



public virtual Nullable<DateTime> Fecha_hora {
        get { return fecha_hora; } set { fecha_hora = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual Nullable<DateTime> Fecha_solicitud {
        get { return fecha_solicitud; } set { fecha_solicitud = value;  }
}





public ReservaEN()
{
        notificacion = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN>();
}



public ReservaEN(int id, LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registrado, LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante, int comensales, LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum estado, bool finalizada, Nullable<DateTime> fecha_hora, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, Nullable<DateTime> fecha_solicitud
                 )
{
        this.init (Id, registrado, restaurante, comensales, estado, finalizada, fecha_hora, notificacion, fecha_solicitud);
}


public ReservaEN(ReservaEN reserva)
{
        this.init (Id, reserva.Registrado, reserva.Restaurante, reserva.Comensales, reserva.Estado, reserva.Finalizada, reserva.Fecha_hora, reserva.Notificacion, reserva.Fecha_solicitud);
}

private void init (int id
                   , LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registrado, LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante, int comensales, LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum estado, bool finalizada, Nullable<DateTime> fecha_hora, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, Nullable<DateTime> fecha_solicitud)
{
        this.Id = id;


        this.Registrado = registrado;

        this.Restaurante = restaurante;

        this.Comensales = comensales;

        this.Estado = estado;

        this.Finalizada = finalizada;

        this.Fecha_hora = fecha_hora;

        this.Notificacion = notificacion;

        this.Fecha_solicitud = fecha_solicitud;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReservaEN t = obj as ReservaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
