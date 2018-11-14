
using System;
// Definición clase RegistradoEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class RegistradoEN                                                                   : LePapeoGenNHibernate.EN.LePapeo.UsuarioEN


{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo fecha_nac
 */
private Nullable<DateTime> fecha_nac;



/**
 *	Atributo reserva
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> reserva;



/**
 *	Atributo opinion
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> opinion;



/**
 *	Atributo direccion_0
 */
private LePapeoGenNHibernate.EN.LePapeo.DireccionEN direccion_0;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual Nullable<DateTime> Fecha_nac {
        get { return fecha_nac; } set { fecha_nac = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> Reserva {
        get { return reserva; } set { reserva = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> Opinion {
        get { return opinion; } set { opinion = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.DireccionEN Direccion_0 {
        get { return direccion_0; } set { direccion_0 = value;  }
}





public RegistradoEN() : base ()
{
        reserva = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
        opinion = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
}



public RegistradoEN(int id, string nombre, string apellidos, Nullable<DateTime> fecha_nac, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> reserva, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> opinion, LePapeoGenNHibernate.EN.LePapeo.DireccionEN direccion_0
                    , string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion
                    )
{
        this.init (Id, nombre, apellidos, fecha_nac, reserva, opinion, direccion_0, email, pass, notificacion);
}


public RegistradoEN(RegistradoEN registrado)
{
        this.init (Id, registrado.Nombre, registrado.Apellidos, registrado.Fecha_nac, registrado.Reserva, registrado.Opinion, registrado.Direccion_0, registrado.Email, registrado.Pass, registrado.Notificacion);
}

private void init (int id
                   , string nombre, string apellidos, Nullable<DateTime> fecha_nac, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> reserva, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> opinion, LePapeoGenNHibernate.EN.LePapeo.DireccionEN direccion_0, string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Fecha_nac = fecha_nac;

        this.Reserva = reserva;

        this.Opinion = opinion;

        this.Direccion_0 = direccion_0;

        this.Email = email;

        this.Pass = pass;

        this.Notificacion = notificacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RegistradoEN t = obj as RegistradoEN;
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
