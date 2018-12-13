
using System;
// Definición clase NotificacionEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo notificacionGenerica
 */
private LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN notificacionGenerica;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo enviada
 */
private bool enviada;



/**
 *	Atributo usuario
 */
private LePapeoGenNHibernate.EN.LePapeo.UsuarioEN usuario;



/**
 *	Atributo opinion
 */
private LePapeoGenNHibernate.EN.LePapeo.OpinionEN opinion;



/**
 *	Atributo reserva
 */
private LePapeoGenNHibernate.EN.LePapeo.ReservaEN reserva;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN NotificacionGenerica {
        get { return notificacionGenerica; } set { notificacionGenerica = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual bool Enviada {
        get { return enviada; } set { enviada = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.OpinionEN Opinion {
        get { return opinion; } set { opinion = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.ReservaEN Reserva {
        get { return reserva; } set { reserva = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, string contenido, LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN notificacionGenerica, Nullable<DateTime> fecha, bool enviada, LePapeoGenNHibernate.EN.LePapeo.UsuarioEN usuario, LePapeoGenNHibernate.EN.LePapeo.OpinionEN opinion, LePapeoGenNHibernate.EN.LePapeo.ReservaEN reserva
                      )
{
        this.init (Id, contenido, notificacionGenerica, fecha, enviada, usuario, opinion, reserva);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Contenido, notificacion.NotificacionGenerica, notificacion.Fecha, notificacion.Enviada, notificacion.Usuario, notificacion.Opinion, notificacion.Reserva);
}

private void init (int id
                   , string contenido, LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN notificacionGenerica, Nullable<DateTime> fecha, bool enviada, LePapeoGenNHibernate.EN.LePapeo.UsuarioEN usuario, LePapeoGenNHibernate.EN.LePapeo.OpinionEN opinion, LePapeoGenNHibernate.EN.LePapeo.ReservaEN reserva)
{
        this.Id = id;


        this.Contenido = contenido;

        this.NotificacionGenerica = notificacionGenerica;

        this.Fecha = fecha;

        this.Enviada = enviada;

        this.Usuario = usuario;

        this.Opinion = opinion;

        this.Reserva = reserva;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
