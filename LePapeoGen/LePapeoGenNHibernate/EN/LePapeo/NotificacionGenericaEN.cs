
using System;
// Definición clase NotificacionGenericaEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class NotificacionGenericaEN
{
/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipo
 */
private LePapeoGenNHibernate.Enumerated.LePapeo.TipoNotificacionEnum tipo; 



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo nombre
 */
private string nombre;






public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual LePapeoGenNHibernate.Enumerated.LePapeo.TipoNotificacionEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}





public NotificacionGenericaEN()
{
        notificacion = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN>();
}



public NotificacionGenericaEN(int id, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, LePapeoGenNHibernate.Enumerated.LePapeo.TipoNotificacionEnum tipo, string texto, string nombre
                              )
{
        this.init (Id, notificacion, tipo, texto, nombre);
}


public NotificacionGenericaEN(NotificacionGenericaEN notificacionGenerica)
{
        this.init (Id, notificacionGenerica.Notificacion, notificacionGenerica.Tipo, notificacionGenerica.Texto, notificacionGenerica.Nombre);
}

private void init (int id
                   , System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, LePapeoGenNHibernate.Enumerated.LePapeo.TipoNotificacionEnum tipo, string texto, string nombre)
{
        this.Id = id;


        this.Notificacion = notificacion;

        this.Tipo = tipo;

        this.Texto = texto;

        this.Nombre = nombre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionGenericaEN t = obj as NotificacionGenericaEN;
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
