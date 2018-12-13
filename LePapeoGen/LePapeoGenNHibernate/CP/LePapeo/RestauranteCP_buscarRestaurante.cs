
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;



/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CP.LePapeo_Restaurante_buscarRestaurante) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CP.LePapeo
{
public partial class RestauranteCP : BasicCP
{
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> BuscarRestaurante (string p_cadena)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CP.LePapeo_Restaurante_buscarRestaurante) ENABLED START*/

        IRestauranteCAD restauranteCAD = null;
        RestauranteCEN restauranteCEN = null;

        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN>  result = null;


        try
        {
                SessionInitializeTransaction ();
                restauranteCAD = new RestauranteCAD (session);
                restauranteCEN = new  RestauranteCEN (restauranteCAD);




                return restauranteCAD.BuscarRestaurante (p_cadena);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
