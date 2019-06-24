
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.Exceptions;
using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;


/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CEN.LePapeo_Restaurante_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CEN.LePapeo
{
public partial class RestauranteCEN
{
public void Modify (int p_Restaurante_OID, string p_email, String p_pass, Nullable<DateTime> p_fecha_inscripcion, string p_nombre, Nullable<DateTime> p_fecha_apertura, int p_max_comen, int p_current_comen, float p_precio_medio, string p_descripcion, string p_menu)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CEN.LePapeo_Restaurante_modify_customized) START*/

        RestauranteEN restauranteEN = null;

        //Initialized RestauranteEN
        restauranteEN = new RestauranteEN ();
        restauranteEN.Id = p_Restaurante_OID;
        restauranteEN.Email = p_email;
        //restauranteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        restauranteEN.Pass = p_pass;
        restauranteEN.Fecha_inscripcion = p_fecha_inscripcion;
        restauranteEN.Nombre = p_nombre;
        restauranteEN.Fecha_apertura = p_fecha_apertura;
        restauranteEN.Max_comen = p_max_comen;
        restauranteEN.Current_comen = p_current_comen;
        restauranteEN.Precio_medio = p_precio_medio;
        restauranteEN.Descripcion = p_descripcion;
        restauranteEN.Menu = p_menu;
        //Call to RestauranteCAD

        _IRestauranteCAD.Modify (restauranteEN);

        /*PROTECTED REGION END*/
}
}
}
