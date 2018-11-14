
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



/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CP.LePapeo_Reserva_crearReserva) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CP.LePapeo
{
public partial class ReservaCP : BasicCP
{
public int CrearReserva (int p_comensale, LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum p_estado, int p_registrado, int p_restaurante, bool p_finalizada, Nullable<DateTime> p_fecha_hora)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CP.LePapeo_Reserva_crearReserva) ENABLED START*/

        IReservaCAD reservaCAD = null;
        ReservaCEN reservaCEN = null;

        int result = -1;


        try
        {
                SessionInitializeTransaction ();
                reservaCAD = new ReservaCAD (session);
                reservaCEN = new  ReservaCEN (reservaCAD);


                RestauranteCAD restauranteCAD = new RestauranteCAD (session);
                RestauranteEN restauranteEN = restauranteCAD.ReadOIDDefault (p_restaurante);

                if ((restauranteEN.Max_comen - restauranteEN.Current_comen) >= p_comensale) {
                        result = reservaCEN.New_ (p_registrado, p_restaurante, p_comensale, p_estado, p_finalizada, p_fecha_hora);
                        restauranteEN.Current_comen += p_comensale;

                        restauranteCAD.Modify (restauranteEN);
                }

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
