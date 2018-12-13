
using System;
// Definición clase DireccionEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class DireccionEN
{
/**
 *	Atributo cod_pos
 */
private string cod_pos;



/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo restaurante
 */
private LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante;



/**
 *	Atributo registrado
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RegistradoEN> registrado;



/**
 *	Atributo numero
 */
private int numero;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pos_x
 */
private int pos_x;



/**
 *	Atributo pos_y
 */
private int pos_y;



/**
 *	Atributo ciudad
 */
private LePapeoGenNHibernate.EN.LePapeo.CiudadEN ciudad;






public virtual string Cod_pos {
        get { return cod_pos; } set { cod_pos = value;  }
}



public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.RestauranteEN Restaurante {
        get { return restaurante; } set { restaurante = value;  }
}



public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RegistradoEN> Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Pos_x {
        get { return pos_x; } set { pos_x = value;  }
}



public virtual int Pos_y {
        get { return pos_y; } set { pos_y = value;  }
}



public virtual LePapeoGenNHibernate.EN.LePapeo.CiudadEN Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}





public DireccionEN()
{
        registrado = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.RegistradoEN>();
}



public DireccionEN(int id, string cod_pos, string calle, LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RegistradoEN> registrado, int numero, int pos_x, int pos_y, LePapeoGenNHibernate.EN.LePapeo.CiudadEN ciudad
                   )
{
        this.init (Id, cod_pos, calle, restaurante, registrado, numero, pos_x, pos_y, ciudad);
}


public DireccionEN(DireccionEN direccion)
{
        this.init (Id, direccion.Cod_pos, direccion.Calle, direccion.Restaurante, direccion.Registrado, direccion.Numero, direccion.Pos_x, direccion.Pos_y, direccion.Ciudad);
}

private void init (int id
                   , string cod_pos, string calle, LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restaurante, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RegistradoEN> registrado, int numero, int pos_x, int pos_y, LePapeoGenNHibernate.EN.LePapeo.CiudadEN ciudad)
{
        this.Id = id;


        this.Cod_pos = cod_pos;

        this.Calle = calle;

        this.Restaurante = restaurante;

        this.Registrado = registrado;

        this.Numero = numero;

        this.Pos_x = pos_x;

        this.Pos_y = pos_y;

        this.Ciudad = ciudad;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DireccionEN t = obj as DireccionEN;
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
