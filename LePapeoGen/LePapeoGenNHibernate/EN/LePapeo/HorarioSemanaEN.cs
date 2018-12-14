
using System;
// Definición clase HorarioSemanaEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class HorarioSemanaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo horarioDia
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> horarioDia;



/**
 *	Atributo restaurante
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> restaurante;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> HorarioDia {
        get { return horarioDia; } set { horarioDia = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> Restaurante {
        get { return restaurante; } set { restaurante = value;  }
}





public HorarioSemanaEN()
{
        horarioDia = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN>();
        restaurante = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN>();
}



public HorarioSemanaEN(int id, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> horarioDia, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> restaurante
                       )
{
        this.init (Id, horarioDia, restaurante);
}


public HorarioSemanaEN(HorarioSemanaEN horarioSemana)
{
        this.init (Id, horarioSemana.HorarioDia, horarioSemana.Restaurante);
}

private void init (int id
                   , System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> horarioDia, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> restaurante)
{
        this.Id = id;


        this.HorarioDia = horarioDia;

        this.Restaurante = restaurante;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        HorarioSemanaEN t = obj as HorarioSemanaEN;
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
