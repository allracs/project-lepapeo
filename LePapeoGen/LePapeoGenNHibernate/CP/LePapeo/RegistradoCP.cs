
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
public partial class RegistradoCP : BasicCP
{
public RegistradoCP() : base ()
{
}

public RegistradoCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
