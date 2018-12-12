

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
 *      Definition of the class DireccionCEN
 *
 */
public partial class DireccionCEN
{
private IDireccionCAD _IDireccionCAD;

public DireccionCEN()
{
        this._IDireccionCAD = new DireccionCAD ();
}

public DireccionCEN(IDireccionCAD _IDireccionCAD)
{
        this._IDireccionCAD = _IDireccionCAD;
}

public IDireccionCAD get_IDireccionCAD ()
{
        return this._IDireccionCAD;
}

public int New_ (string p_cod_pos, string p_calle, int p_numero, int p_pos_x, int p_pos_y, string p_ciudad)
{
        DireccionEN direccionEN = null;
        int oid;

        //Initialized DireccionEN
        direccionEN = new DireccionEN ();
        direccionEN.Cod_pos = p_cod_pos;

        direccionEN.Calle = p_calle;

        direccionEN.Numero = p_numero;

        direccionEN.Pos_x = p_pos_x;

        direccionEN.Pos_y = p_pos_y;


        if (p_ciudad != null) {
                // El argumento p_ciudad -> Property ciudad es oid = false
                // Lista de oids id
                direccionEN.Ciudad = new LePapeoGenNHibernate.EN.LePapeo.CiudadEN ();
                direccionEN.Ciudad.Nombre = p_ciudad;
        }

        //Call to DireccionCAD

        oid = _IDireccionCAD.New_ (direccionEN);
        return oid;
}

public void Modify (int p_Direccion_OID, string p_cod_pos, string p_calle, int p_numero, int p_pos_x, int p_pos_y)
{
        DireccionEN direccionEN = null;

        //Initialized DireccionEN
        direccionEN = new DireccionEN ();
        direccionEN.Id = p_Direccion_OID;
        direccionEN.Cod_pos = p_cod_pos;
        direccionEN.Calle = p_calle;
        direccionEN.Numero = p_numero;
        direccionEN.Pos_x = p_pos_x;
        direccionEN.Pos_y = p_pos_y;
        //Call to DireccionCAD

        _IDireccionCAD.Modify (direccionEN);
}

public void Destroy (int id
                     )
{
        _IDireccionCAD.Destroy (id);
}

public System.Collections.Generic.IList<DireccionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> list = null;

        list = _IDireccionCAD.ReadAll (first, size);
        return list;
}
}
}
