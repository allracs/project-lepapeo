
using System;
using System.Text;
using LePapeoGenNHibernate.CEN.LePapeo;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.Exceptions;


/*
 * Clase TipoCocina:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class TipoCocinaCAD : BasicCAD, ITipoCocinaCAD
{
public TipoCocinaCAD() : base ()
{
}

public TipoCocinaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TipoCocinaEN ReadOIDDefault (string tipo
                                    )
{
        TipoCocinaEN tipoCocinaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoCocinaEN = (TipoCocinaEN)session.Get (typeof(TipoCocinaEN), tipo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in TipoCocinaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoCocinaEN;
}

public System.Collections.Generic.IList<TipoCocinaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TipoCocinaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TipoCocinaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TipoCocinaEN>();
                        else
                                result = session.CreateCriteria (typeof(TipoCocinaEN)).List<TipoCocinaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in TipoCocinaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TipoCocinaEN tipoCocina)
{
        try
        {
                SessionInitializeTransaction ();
                TipoCocinaEN tipoCocinaEN = (TipoCocinaEN)session.Load (typeof(TipoCocinaEN), tipoCocina.Tipo);

                session.Update (tipoCocinaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in TipoCocinaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (TipoCocinaEN tipoCocina)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tipoCocina);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in TipoCocinaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoCocina.Tipo;
}

public void Modify (TipoCocinaEN tipoCocina)
{
        try
        {
                SessionInitializeTransaction ();
                TipoCocinaEN tipoCocinaEN = (TipoCocinaEN)session.Load (typeof(TipoCocinaEN), tipoCocina.Tipo);
                session.Update (tipoCocinaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in TipoCocinaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string tipo
                     )
{
        try
        {
                SessionInitializeTransaction ();
                TipoCocinaEN tipoCocinaEN = (TipoCocinaEN)session.Load (typeof(TipoCocinaEN), tipo);
                session.Delete (tipoCocinaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in TipoCocinaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
