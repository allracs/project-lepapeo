

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
 *      Definition of the class RestauranteCEN
 *
 */
public partial class RestauranteCEN
{
private IRestauranteCAD _IRestauranteCAD;

public RestauranteCEN()
{
        this._IRestauranteCAD = new RestauranteCAD ();
}

public RestauranteCEN(IRestauranteCAD _IRestauranteCAD)
{
        this._IRestauranteCAD = _IRestauranteCAD;
}

public IRestauranteCAD get_IRestauranteCAD ()
{
        return this._IRestauranteCAD;
}

public int New_ (string p_email, String p_pass, Nullable<DateTime> p_fecha_inscripcion, string p_nombre, Nullable<DateTime> p_fecha_apertura, string p_tipoCocina, int p_max_comen, int p_current_comen, float p_precio_medio, string p_descripcion, string p_menu)
{
        RestauranteEN restauranteEN = null;
        int oid;

        //Initialized RestauranteEN
        restauranteEN = new RestauranteEN ();
        restauranteEN.Email = p_email;

        restauranteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        restauranteEN.Fecha_inscripcion = p_fecha_inscripcion;

        restauranteEN.Nombre = p_nombre;

        restauranteEN.Fecha_apertura = p_fecha_apertura;


        if (p_tipoCocina != null) {
                // El argumento p_tipoCocina -> Property tipoCocina es oid = false
                // Lista de oids id
                restauranteEN.TipoCocina = new LePapeoGenNHibernate.EN.LePapeo.TipoCocinaEN ();
                restauranteEN.TipoCocina.Tipo = p_tipoCocina;
        }

        restauranteEN.Max_comen = p_max_comen;

        restauranteEN.Current_comen = p_current_comen;

        restauranteEN.Precio_medio = p_precio_medio;

        restauranteEN.Descripcion = p_descripcion;

        restauranteEN.Menu = p_menu;

        //Call to RestauranteCAD

        oid = _IRestauranteCAD.New_ (restauranteEN);
        return oid;
}

public void Destroy (int id
                     )
{
        _IRestauranteCAD.Destroy (id);
}

public RestauranteEN ReadOID (int id
                              )
{
        RestauranteEN restauranteEN = null;

        restauranteEN = _IRestauranteCAD.ReadOID (id);
        return restauranteEN;
}

public System.Collections.Generic.IList<RestauranteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RestauranteEN> list = null;

        list = _IRestauranteCAD.ReadAll (first, size);
        return list;
}
public void AgregarDireccion (int p_Restaurante_OID, int p_direccion_OID)
{
        //Call to RestauranteCAD

        _IRestauranteCAD.AgregarDireccion (p_Restaurante_OID, p_direccion_OID);
}
public void DesvincularDireccion (int p_Restaurante_OID, int p_direccion_OID)
{
        //Call to RestauranteCAD

        _IRestauranteCAD.DesvincularDireccion (p_Restaurante_OID, p_direccion_OID);
}
public void AgregarHorarioSemana (int p_Restaurante_OID, int p_horarioSemana_OID)
{
        //Call to RestauranteCAD

        _IRestauranteCAD.AgregarHorarioSemana (p_Restaurante_OID, p_horarioSemana_OID);
}
public void DesvincularHorarioSemana (int p_Restaurante_OID, int p_horarioSemana_OID)
{
        //Call to RestauranteCAD

        _IRestauranteCAD.DesvincularHorarioSemana (p_Restaurante_OID, p_horarioSemana_OID);
}
public LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN GetHorarioSemana (int p_restaurante)
{
        return _IRestauranteCAD.GetHorarioSemana (p_restaurante);
}
public LePapeoGenNHibernate.EN.LePapeo.DireccionEN GetDireccion (int p_restaurante)
{
        return _IRestauranteCAD.GetDireccion (p_restaurante);
}
}
}
