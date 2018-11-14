
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


/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CEN.LePapeo_Reserva_cambiarFinalizacion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CEN.LePapeo
{
public partial class ReservaCEN
{
public void CambiarFinalizacion (bool p_finalizada, int p_OID)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CEN.LePapeo_Reserva_cambiarFinalizacion_customized) START*/

        ReservaEN reservaEN = null;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();
        reservaEN.Finalizada = p_finalizada;
        reservaEN.Id = p_OID;
        //Call to ReservaCAD

        _IReservaCAD.CambiarFinalizacion (reservaEN);

        /*PROTECTED REGION END*/
}
}
}
