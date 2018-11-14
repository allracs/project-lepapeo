
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
public partial class ReservaCP : BasicCP
{
public ReservaCP() : base ()
{
}

public ReservaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
