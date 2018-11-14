
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using LePapeoGenNHibernate.Exceptions;
using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;



namespace LePapeoGenNHibernate.CP.LePapeo
{
public partial class NotificacionGenericaCP : BasicCP
{
public NotificacionGenericaCP() : base ()
{
}

public NotificacionGenericaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
