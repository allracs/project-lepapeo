
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


/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CEN.LePapeo_Reserva_cambiarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CEN.LePapeo
{
public partial class ReservaCEN
{
public void CambiarEstado (LePapeoGenNHibernate.Enumerated.LePapeo.EstadoReservaEnum p_estado, int p_OID)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CEN.LePapeo_Reserva_cambiarEstado_customized) START*/

        ReservaEN reservaEN = null;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();
        reservaEN.Estado = p_estado;
        reservaEN.Id = p_OID;
        //Call to ReservaCAD

        _IReservaCAD.CambiarEstado (reservaEN);

        /*PROTECTED REGION END*/
}
}
}
