
using System;
// Definición clase OpinionEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class OpinionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valoracion
 */
private LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum valoracion;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo registrado
 */
private LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registrado;



/**
 *	Atributo restaurante
 */
private LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.RestauranteEN Restaurante {
        get { return restaurante; } set { restaurante = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public OpinionEN()
{
        notificacion = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN>();
}



public OpinionEN(int id, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum valoracion, string titulo, string comentario, LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registrado, LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, Nullable<DateTime> fecha
                 )
{
        this.init (Id, valoracion, titulo, comentario, registrado, restaurante, notificacion, fecha);
}


public OpinionEN(OpinionEN opinion)
{
        this.init (Id, opinion.Valoracion, opinion.Titulo, opinion.Comentario, opinion.Registrado, opinion.Restaurante, opinion.Notificacion, opinion.Fecha);
}

private void init (int id
                   , LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum valoracion, string titulo, string comentario, LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registrado, LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Valoracion = valoracion;

        this.Titulo = titulo;

        this.Comentario = comentario;

        this.Registrado = registrado;

        this.Restaurante = restaurante;

        this.Notificacion = notificacion;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        OpinionEN t = obj as OpinionEN;
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
