
using System;
// Definición clase HorarioDiaEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class HorarioDiaEN
{
/**
 *	Atributo hora_ini_am
 */
private Nullable<DateTime> hora_ini_am;



/**
 *	Atributo hora_fin_am
 */
private Nullable<DateTime> hora_fin_am;



/**
 *	Atributo hora_ini_pm
 */
private Nullable<DateTime> hora_ini_pm;



/**
 *	Atributo hora_fin_pm
 */
private Nullable<DateTime> hora_fin_pm;



/**
 *	Atributo dia
 */
private LePapeoGenNHibernate.Enumerated.LePapeo.DiaSemanaEnum dia;



/**
 *	Atributo horarioSemana
 */
private LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN horarioSemana;



/**
 *	Atributo id
 */
private int id;






public virtual Nullable<DateTime> Hora_ini_am {
        get { return hora_ini_am; } set { hora_ini_am = value;  }
}



public virtual Nullable<DateTime> Hora_fin_am {
        get { return hora_fin_am; } set { hora_fin_am = value;  }
}



public virtual Nullable<DateTime> Hora_ini_pm {
        get { return hora_ini_pm; } set { hora_ini_pm = value;  }
}



public virtual Nullable<DateTime> Hora_fin_pm {
        get { return hora_fin_pm; } set { hora_fin_pm = value;  }
}



public virtual LePapeoGenNHibernate.Enumerated.LePapeo.DiaSemanaEnum Dia {
        get { return dia; } set { dia = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN HorarioSemana {
        get { return horarioSemana; } set { horarioSemana = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public HorarioDiaEN()
{
}



public HorarioDiaEN(int id, Nullable<DateTime> hora_ini_am, Nullable<DateTime> hora_fin_am, Nullable<DateTime> hora_ini_pm, Nullable<DateTime> hora_fin_pm, LePapeoGenNHibernate.Enumerated.LePapeo.DiaSemanaEnum dia, LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN horarioSemana
                    )
{
        this.init (Id, hora_ini_am, hora_fin_am, hora_ini_pm, hora_fin_pm, dia, horarioSemana);
}


public HorarioDiaEN(HorarioDiaEN horarioDia)
{
        this.init (Id, horarioDia.Hora_ini_am, horarioDia.Hora_fin_am, horarioDia.Hora_ini_pm, horarioDia.Hora_fin_pm, horarioDia.Dia, horarioDia.HorarioSemana);
}

private void init (int id
                   , Nullable<DateTime> hora_ini_am, Nullable<DateTime> hora_fin_am, Nullable<DateTime> hora_ini_pm, Nullable<DateTime> hora_fin_pm, LePapeoGenNHibernate.Enumerated.LePapeo.DiaSemanaEnum dia, LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN horarioSemana)
{
        this.Id = id;


        this.Hora_ini_am = hora_ini_am;

        this.Hora_fin_am = hora_fin_am;

        this.Hora_ini_pm = hora_ini_pm;

        this.Hora_fin_pm = hora_fin_pm;

        this.Dia = dia;

        this.HorarioSemana = horarioSemana;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        HorarioDiaEN t = obj as HorarioDiaEN;
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
