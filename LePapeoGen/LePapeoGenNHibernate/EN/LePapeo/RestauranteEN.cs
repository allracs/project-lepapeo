
using System;
// Definición clase RestauranteEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class RestauranteEN                                                                  : LePapeoGenNHibernate.EN.LePapeo.UsuarioEN


{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fecha_apertura
 */
private Nullable<DateTime> fecha_apertura;



/**
 *	Atributo reserva_0
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> reserva_0;



/**
 *	Atributo opinion_0
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> opinion_0;



/**
 *	Atributo horarioSemana
 */
private LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN horarioSemana;



/**
 *	Atributo direccion
 */
private LePapeoGenNHibernate.EN.LePapeo.DireccionEN direccion;



/**
 *	Atributo tipoCocina
 */
private LePapeoGenNHibernate.EN.LePapeo.TipoCocinaEN tipoCocina;



/**
 *	Atributo max_comen
 */
private int max_comen;



/**
 *	Atributo current_comen
 */
private int current_comen;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> Fecha_apertura {
        get { return fecha_apertura; } set { fecha_apertura = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> Reserva_0 {
        get { return reserva_0; } set { reserva_0 = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> Opinion_0 {
        get { return opinion_0; } set { opinion_0 = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN HorarioSemana {
        get { return horarioSemana; } set { horarioSemana = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.DireccionEN Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.TipoCocinaEN TipoCocina {
        get { return tipoCocina; } set { tipoCocina = value;  }
}



public virtual int Max_comen {
        get { return max_comen; } set { max_comen = value;  }
}



public virtual int Current_comen {
        get { return current_comen; } set { current_comen = value;  }
}





public RestauranteEN() : base ()
{
        reserva_0 = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
        opinion_0 = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
}



public RestauranteEN(int id, string nombre, Nullable<DateTime> fecha_apertura, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> reserva_0, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> opinion_0, LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN horarioSemana, LePapeoGenNHibernate.EN.LePapeo.DireccionEN direccion, LePapeoGenNHibernate.EN.LePapeo.TipoCocinaEN tipoCocina, int max_comen, int current_comen
                     , string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion
                     )
{
        this.init (Id, nombre, fecha_apertura, reserva_0, opinion_0, horarioSemana, direccion, tipoCocina, max_comen, current_comen, email, pass, notificacion);
}


public RestauranteEN(RestauranteEN restaurante)
{
        this.init (Id, restaurante.Nombre, restaurante.Fecha_apertura, restaurante.Reserva_0, restaurante.Opinion_0, restaurante.HorarioSemana, restaurante.Direccion, restaurante.TipoCocina, restaurante.Max_comen, restaurante.Current_comen, restaurante.Email, restaurante.Pass, restaurante.Notificacion);
}

private void init (int id
                   , string nombre, Nullable<DateTime> fecha_apertura, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> reserva_0, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> opinion_0, LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN horarioSemana, LePapeoGenNHibernate.EN.LePapeo.DireccionEN direccion, LePapeoGenNHibernate.EN.LePapeo.TipoCocinaEN tipoCocina, int max_comen, int current_comen, string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Fecha_apertura = fecha_apertura;

        this.Reserva_0 = reserva_0;

        this.Opinion_0 = opinion_0;

        this.HorarioSemana = horarioSemana;

        this.Direccion = direccion;

        this.TipoCocina = tipoCocina;

        this.Max_comen = max_comen;

        this.Current_comen = current_comen;

        this.Email = email;

        this.Pass = pass;

        this.Notificacion = notificacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RestauranteEN t = obj as RestauranteEN;
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
