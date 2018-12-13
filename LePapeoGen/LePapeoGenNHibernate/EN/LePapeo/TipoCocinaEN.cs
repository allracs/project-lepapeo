
using System;
// Definición clase TipoCocinaEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class TipoCocinaEN
{
/**
 *	Atributo tipo
 */
private string tipo;



/**
 *	Atributo restaurante
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> restaurante;






public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> Restaurante {
        get { return restaurante; } set { restaurante = value;  }
}





public TipoCocinaEN()
{
        restaurante = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN>();
}



public TipoCocinaEN(string tipo, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> restaurante
                    )
{
        this.init (Tipo, restaurante);
}


public TipoCocinaEN(TipoCocinaEN tipoCocina)
{
        this.init (Tipo, tipoCocina.Restaurante);
}

private void init (string tipo
                   , System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> restaurante)
{
        this.Tipo = tipo;


        this.Restaurante = restaurante;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TipoCocinaEN t = obj as TipoCocinaEN;
        if (t == null)
                return false;
        if (Tipo.Equals (t.Tipo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Tipo.GetHashCode ();
        return hash;
}
}
}
