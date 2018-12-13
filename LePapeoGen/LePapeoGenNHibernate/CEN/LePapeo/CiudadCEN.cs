

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.Exceptions;

using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;


namespace LePapeoGenNHibernate.CEN.LePapeo
{
/*
 *      Definition of the class CiudadCEN
 *
 */
public partial class CiudadCEN
{
private ICiudadCAD _ICiudadCAD;

public CiudadCEN()
{
        this._ICiudadCAD = new CiudadCAD ();
}

public CiudadCEN(ICiudadCAD _ICiudadCAD)
{
        this._ICiudadCAD = _ICiudadCAD;
}

public ICiudadCAD get_ICiudadCAD ()
{
        return this._ICiudadCAD;
}

public string New_ (string p_nombre, string p_provincia)
{
        CiudadEN ciudadEN = null;
        string oid;

        //Initialized CiudadEN
        ciudadEN = new CiudadEN ();
        ciudadEN.Nombre = p_nombre;

        ciudadEN.Provincia = p_provincia;

        //Call to CiudadCAD

        oid = _ICiudadCAD.New_ (ciudadEN);
        return oid;
}

public void Modify (string p_Ciudad_OID, string p_provincia)
{
        CiudadEN ciudadEN = null;

        //Initialized CiudadEN
        ciudadEN = new CiudadEN ();
        ciudadEN.Nombre = p_Ciudad_OID;
        ciudadEN.Provincia = p_provincia;
        //Call to CiudadCAD

        _ICiudadCAD.Modify (ciudadEN);
}

public void Destroy (string nombre
                     )
{
        _ICiudadCAD.Destroy (nombre);
}

public System.Collections.Generic.IList<CiudadEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CiudadEN> list = null;

        list = _ICiudadCAD.ReadAll (first, size);
        return list;
}
public CiudadEN ReadOID (string nombre
                         )
{
        CiudadEN ciudadEN = null;

        ciudadEN = _ICiudadCAD.ReadOID (nombre);
        return ciudadEN;
}
}
}
