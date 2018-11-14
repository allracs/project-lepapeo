
using System;
// Definición clase UsuarioEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class UsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}





public UsuarioEN()
{
        notificacion = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN>();
}



public UsuarioEN(int id, string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion
                 )
{
        this.init (Id, email, pass, notificacion);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Email, usuario.Pass, usuario.Notificacion);
}

private void init (int id
                   , string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion)
{
        this.Id = id;


        this.Email = email;

        this.Pass = pass;

        this.Notificacion = notificacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
