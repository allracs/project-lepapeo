

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.Exceptions;

using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;


namespace LePapeoGenNHibernate.CEN.LePapeo
{
/*
 *      Definition of the class TipoCocinaCEN
 *
 */
public partial class TipoCocinaCEN
{
private ITipoCocinaCAD _ITipoCocinaCAD;

public TipoCocinaCEN()
{
        this._ITipoCocinaCAD = new TipoCocinaCAD ();
}

public TipoCocinaCEN(ITipoCocinaCAD _ITipoCocinaCAD)
{
        this._ITipoCocinaCAD = _ITipoCocinaCAD;
}

public ITipoCocinaCAD get_ITipoCocinaCAD ()
{
        return this._ITipoCocinaCAD;
}

public string New_ (string p_tipo)
{
        TipoCocinaEN tipoCocinaEN = null;
        string oid;

        //Initialized TipoCocinaEN
        tipoCocinaEN = new TipoCocinaEN ();
        tipoCocinaEN.Tipo = p_tipo;

        //Call to TipoCocinaCAD

        oid = _ITipoCocinaCAD.New_ (tipoCocinaEN);
        return oid;
}

public void Modify (string p_TipoCocina_OID)
{
        TipoCocinaEN tipoCocinaEN = null;

        //Initialized TipoCocinaEN
        tipoCocinaEN = new TipoCocinaEN ();
        tipoCocinaEN.Tipo = p_TipoCocina_OID;
        //Call to TipoCocinaCAD

        _ITipoCocinaCAD.Modify (tipoCocinaEN);
}

public void Destroy (string tipo
                     )
{
        _ITipoCocinaCAD.Destroy (tipo);
}
}
}
