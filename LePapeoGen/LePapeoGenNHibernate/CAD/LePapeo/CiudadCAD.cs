
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
 * Clase Ciudad:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class CiudadCAD : BasicCAD, ICiudadCAD
{
public CiudadCAD() : base ()
{
}

public CiudadCAD(ISession sessionAux) : base (sessionAux)
{
}



public CiudadEN ReadOIDDefault (string nombre
                                )
{
        CiudadEN ciudadEN = null;

        try
        {
                SessionInitializeTransaction ();
                ciudadEN = (CiudadEN)session.Get (typeof(CiudadEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in CiudadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ciudadEN;
}

public System.Collections.Generic.IList<CiudadEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CiudadEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CiudadEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CiudadEN>();
                        else
                                result = session.CreateCriteria (typeof(CiudadEN)).List<CiudadEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in CiudadCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CiudadEN ciudad)
{
        try
        {
                SessionInitializeTransaction ();
                CiudadEN ciudadEN = (CiudadEN)session.Load (typeof(CiudadEN), ciudad.Nombre);


                ciudadEN.Provincia = ciudad.Provincia;

                session.Update (ciudadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in CiudadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (CiudadEN ciudad)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (ciudad);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in CiudadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ciudad.Nombre;
}

public void Modify (CiudadEN ciudad)
{
        try
        {
                SessionInitializeTransaction ();
                CiudadEN ciudadEN = (CiudadEN)session.Load (typeof(CiudadEN), ciudad.Nombre);

                ciudadEN.Provincia = ciudad.Provincia;

                session.Update (ciudadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in CiudadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string nombre
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CiudadEN ciudadEN = (CiudadEN)session.Load (typeof(CiudadEN), nombre);
                session.Delete (ciudadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in CiudadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
