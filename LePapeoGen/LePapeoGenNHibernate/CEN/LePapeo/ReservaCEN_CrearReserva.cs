
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


/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CEN.LePapeo_Reserva_crearReserva) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CEN.LePapeo
{
public partial class ReservaCEN
{
public int CrearReserva (int p_comensale, LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum p_estado, int p_registrado, int p_restaurante, bool p_finalizada, Nullable<DateTime> p_fecha_hora)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CEN.LePapeo_Reserva_crearReserva) ENABLED START*/


        RestauranteCAD restauranteCAD = new RestauranteCAD ();
        RestauranteEN restauranteEN = restauranteCAD.ReadOIDDefault (p_restaurante);
            int oid = 0;
            ReservaCEN reservaCEN = new ReservaCEN();  

        if ((restauranteEN.Max_comen - restauranteEN.Current_comen) >= p_comensale) {
                oid = reservaCEN.New_(p_registrado, p_restaurante, p_comensale, p_estado, p_finalizada, p_fecha_hora);

                restauranteEN.Current_comen += p_comensale;
                RestauranteCAD.Modify(restauranteEN);

            }


            return oid;
        /*PROTECTED REGION END*/
}
}
}
