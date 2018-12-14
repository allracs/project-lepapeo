
using System;
// Definición clase CiudadEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class CiudadEN
{
/**
 *	Atributo direccion
 */
private System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.DireccionEN> direccion;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo provincia
 */
private string provincia;






public virtual System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.DireccionEN> Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}





public CiudadEN()
{
        direccion = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.DireccionEN>();
}



public CiudadEN(string nombre, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.DireccionEN> direccion, string provincia
                )
{
        this.init (Nombre, direccion, provincia);
}


public CiudadEN(CiudadEN ciudad)
{
        this.init (Nombre, ciudad.Direccion, ciudad.Provincia);
}

private void init (string nombre
                   , System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.DireccionEN> direccion, string provincia)
{
        this.Nombre = nombre;


        this.Direccion = direccion;

        this.Provincia = provincia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CiudadEN t = obj as CiudadEN;
        if (t == null)
                return false;
        if (Nombre.Equals (t.Nombre))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nombre.GetHashCode ();
        return hash;
}
}
}
