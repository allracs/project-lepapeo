
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
 * Clase NotificacionGenerica:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class NotificacionGenericaCAD : BasicCAD, INotificacionGenericaCAD
{
public NotificacionGenericaCAD() : base ()
{
}

public NotificacionGenericaCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionGenericaEN ReadOIDDefault (int id
                                              )
{
        NotificacionGenericaEN notificacionGenericaEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionGenericaEN = (NotificacionGenericaEN)session.Get (typeof(NotificacionGenericaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionGenericaEN;
}

public System.Collections.Generic.IList<NotificacionGenericaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionGenericaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionGenericaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionGenericaEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionGenericaEN)).List<NotificacionGenericaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionGenericaEN notificacionGenerica)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionGenericaEN notificacionGenericaEN = (NotificacionGenericaEN)session.Load (typeof(NotificacionGenericaEN), notificacionGenerica.Id);


                notificacionGenericaEN.Tipo = notificacionGenerica.Tipo;


                notificacionGenericaEN.Texto = notificacionGenerica.Texto;


                notificacionGenericaEN.Nombre = notificacionGenerica.Nombre;

                session.Update (notificacionGenericaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionGenericaEN notificacionGenerica)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (notificacionGenerica);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionGenerica.Id;
}

public void Modify (NotificacionGenericaEN notificacionGenerica)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionGenericaEN notificacionGenericaEN = (NotificacionGenericaEN)session.Load (typeof(NotificacionGenericaEN), notificacionGenerica.Id);

                notificacionGenericaEN.Tipo = notificacionGenerica.Tipo;


                notificacionGenericaEN.Texto = notificacionGenerica.Texto;


                notificacionGenericaEN.Nombre = notificacionGenerica.Nombre;

                session.Update (notificacionGenericaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionGenericaEN notificacionGenericaEN = (NotificacionGenericaEN)session.Load (typeof(NotificacionGenericaEN), id);
                session.Delete (notificacionGenericaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificacionGenericaEN
public NotificacionGenericaEN ReadOID (int id
                                       )
{
        NotificacionGenericaEN notificacionGenericaEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionGenericaEN = (NotificacionGenericaEN)session.Get (typeof(NotificacionGenericaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionGenericaEN;
}

public System.Collections.Generic.IList<NotificacionGenericaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionGenericaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionGenericaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionGenericaEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionGenericaEN)).List<NotificacionGenericaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionGenericaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
