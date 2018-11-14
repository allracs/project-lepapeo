
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



/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CP.LePapeo_Reserva_checkout) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CP.LePapeo
{
public partial class ReservaCP : BasicCP
{
public void Checkout (int p_oid)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CP.LePapeo_Reserva_checkout) ENABLED START*/

        IReservaCAD reservaCAD = null;
        ReservaCEN reservaCEN = null;
            ReservaEN reservaEN = null;


        try
        {
                SessionInitializeTransaction ();
                reservaCAD = new ReservaCAD (session);
                reservaCEN = new  ReservaCEN (reservaCAD);
                reservaEN = reservaCAD.ReadOIDDefault(p_oid);


                RestauranteCAD restauranteCAD = new RestauranteCAD(session);
                RestauranteEN restauranteEN = restauranteCAD.ReadOIDDefault(reservaEN.Restaurante.Id);

                restauranteEN.Current_comen -= reservaEN.Comensales;


                reservaEN.Finalizada = true;


                restauranteCAD.Modify(restauranteEN);
                reservaCAD.Modify(reservaEN);

                SessionCommit();
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


        /*PROTECTED REGION END*/
}
}
}
