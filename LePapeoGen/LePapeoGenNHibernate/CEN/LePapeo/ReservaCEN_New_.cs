
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


/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CEN.LePapeo_Reserva_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CEN.LePapeo
{
public partial class ReservaCEN
{
public LePapeoGenNHibernate.EN.LePapeo.ReservaEN New_ (int p_registrado, int p_restaurante, int p_comensales, LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum p_estado, bool p_finalizada, Nullable<DateTime> p_fecha_hora)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CEN.LePapeo_Reserva_new_) ENABLED START*/

        // Write here your custom code...

        RestauranteEN restauranteEN = new RestauranteEN ();

        RestauranteCAD restauranteCAD = new RestauranteCAD ();

        restauranteEN = restauranteCAD.ReadOIDDefault (p_restaurante);

        if (restauranteEN.Max_comen >= p_comensales) {
                ReservaCEN reservaCEN = new ReservaCEN ();

                reservaCEN.GetReservasFromRestauranteByFechaHora (p_restaurante)
        }





        /*PROTECTED REGION END*/
}
}
}
