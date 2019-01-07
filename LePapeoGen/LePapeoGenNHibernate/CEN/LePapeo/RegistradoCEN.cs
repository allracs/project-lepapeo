

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
 *      Definition of the class RegistradoCEN
 *
 */
public partial class RegistradoCEN
{
private IRegistradoCAD _IRegistradoCAD;

public RegistradoCEN()
{
        this._IRegistradoCAD = new RegistradoCAD ();
}

public RegistradoCEN(IRegistradoCAD _IRegistradoCAD)
{
        this._IRegistradoCAD = _IRegistradoCAD;
}

public IRegistradoCAD get_IRegistradoCAD ()
{
        return this._IRegistradoCAD;
}

public int New_ (string p_email, String p_pass, Nullable<DateTime> p_fecha_inscripcion, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nac)
{
        RegistradoEN registradoEN = null;
        int oid;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Email = p_email;

        registradoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        
        registradoEN.Fecha_inscripcion = p_fecha_inscripcion;

        registradoEN.Nombre = p_nombre;

        registradoEN.Apellidos = p_apellidos;

        registradoEN.Fecha_nac = p_fecha_nac;

        //Call to RegistradoCAD

        oid = _IRegistradoCAD.New_ (registradoEN);
        return oid;
}

public void Modify (int p_Registrado_OID, string p_email, String p_pass, Nullable<DateTime> p_fecha_inscripcion, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nac)
{
        RegistradoEN registradoEN = null;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Id = p_Registrado_OID;
        registradoEN.Email = p_email;
        //registradoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        registradoEN.Pass = p_pass;
        registradoEN.Fecha_inscripcion = p_fecha_inscripcion;
        registradoEN.Nombre = p_nombre;
        registradoEN.Apellidos = p_apellidos;
        registradoEN.Fecha_nac = p_fecha_nac;
        //Call to RegistradoCAD

        _IRegistradoCAD.Modify (registradoEN);
}

public void Destroy (int id
                     )
{
        _IRegistradoCAD.Destroy (id);
}

public RegistradoEN ReadOID (int id
                             )
{
        RegistradoEN registradoEN = null;

        registradoEN = _IRegistradoCAD.ReadOID (id);
        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> list = null;

        list = _IRegistradoCAD.ReadAll (first, size);
        return list;
}
public void AgregarDireccion (int p_Registrado_OID, int p_direccion_0_OID)
{
        //Call to RegistradoCAD

        _IRegistradoCAD.AgregarDireccion (p_Registrado_OID, p_direccion_0_OID);
}
public void DesvincularDireccion (int p_Registrado_OID, int p_direccion_0_OID)
{
        //Call to RegistradoCAD

        _IRegistradoCAD.DesvincularDireccion (p_Registrado_OID, p_direccion_0_OID);
}
public LePapeoGenNHibernate.EN.LePapeo.DireccionEN GetDireccion (int p_registrado)
{
        return _IRegistradoCAD.GetDireccion (p_registrado);
}
}
}
