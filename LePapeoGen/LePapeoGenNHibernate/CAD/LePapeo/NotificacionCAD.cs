
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
 * Clase Notificacion:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class NotificacionCAD : BasicCAD, INotificacionCAD
{
public NotificacionCAD() : base ()
{
}

public NotificacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionEN ReadOIDDefault (int id
                                      )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionEN)).List<NotificacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), notificacion.Id);

                notificacionEN.Contenido = notificacion.Contenido;



                notificacionEN.Fecha = notificacion.Fecha;


                notificacionEN.Enviada = notificacion.Enviada;




                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (notificacion.NotificacionGenerica != null) {
                        // Argumento OID y no colección.
                        notificacion.NotificacionGenerica = (LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.NotificacionGenericaEN), notificacion.NotificacionGenerica.Id);

                        notificacion.NotificacionGenerica.Notificacion
                        .Add (notificacion);
                }

                session.Save (notificacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacion.Id;
}

public void Modify (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), notificacion.Id);

                notificacionEN.Contenido = notificacion.Contenido;


                notificacionEN.Fecha = notificacion.Fecha;


                notificacionEN.Enviada = notificacion.Enviada;

                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
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
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), id);
                session.Delete (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificacionEN
public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionEN)).List<NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AgregarUsuario (int p_Notificacion_OID, int p_usuario_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.NotificacionEN notificacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);
                notificacionEN.Usuario = (LePapeoGenNHibernate.EN.LePapeo.UsuarioEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.UsuarioEN), p_usuario_OID);

                notificacionEN.Usuario.Notificacion.Add (notificacionEN);



                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesvincularUsuario (int p_Notificacion_OID, int p_usuario_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.NotificacionEN notificacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);
                notificacionEN.Usuario = (LePapeoGenNHibernate.EN.LePapeo.UsuarioEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.UsuarioEN), p_usuario_OID);

                notificacionEN.Usuario.Notificacion.Add (notificacionEN);



                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AgregarReserva (int p_Notificacion_OID, int p_reserva_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.NotificacionEN notificacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);
                notificacionEN.Reserva = (LePapeoGenNHibernate.EN.LePapeo.ReservaEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.ReservaEN), p_reserva_OID);

                notificacionEN.Reserva.Notificacion.Add (notificacionEN);



                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesvincularReserva (int p_Notificacion_OID, int p_reserva_OID)
{
        try
        {
                SessionInitializeTransaction ();
                LePapeoGenNHibernate.EN.LePapeo.NotificacionEN notificacionEN = null;
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);

                if (notificacionEN.Reserva.Id == p_reserva_OID) {
                        notificacionEN.Reserva = null;
                }
                else
                        throw new ModelException ("The identifier " + p_reserva_OID + " in p_reserva_OID you are trying to unrelationer, doesn't exist in NotificacionEN");

                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AgregarOpinion (int p_Notificacion_OID, int p_opinion_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.NotificacionEN notificacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);
                notificacionEN.Opinion = (LePapeoGenNHibernate.EN.LePapeo.OpinionEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.OpinionEN), p_opinion_OID);

                notificacionEN.Opinion.Notificacion.Add (notificacionEN);



                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesvincularOpinion (int p_Notificacion_OID, int p_opinion_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.NotificacionEN notificacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);
                notificacionEN.Opinion = (LePapeoGenNHibernate.EN.LePapeo.OpinionEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.OpinionEN), p_opinion_OID);

                notificacionEN.Opinion.Notificacion.Add (notificacionEN);



                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public LePapeoGenNHibernate.EN.LePapeo.RegistradoEN GetUsuario (int p_notificacion)
{
        LePapeoGenNHibernate.EN.LePapeo.RegistradoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionEN self where select noti.Usuario FROM NotificacionEN as noti where noti.id = :p_notificacion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionENgetUsuarioHQL");
                query.SetParameter ("p_notificacion", p_notificacion);


                result = query.UniqueResult<LePapeoGenNHibernate.EN.LePapeo.RegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public LePapeoGenNHibernate.EN.LePapeo.ReservaEN GetReserva (int p_notificacion)
{
        LePapeoGenNHibernate.EN.LePapeo.ReservaEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionEN self where select noti.Reserva FROM NotificacionEN as noti where noti.id = :p_notificacion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionENgetReservaHQL");
                query.SetParameter ("p_notificacion", p_notificacion);


                result = query.UniqueResult<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public LePapeoGenNHibernate.EN.LePapeo.OpinionEN GetOpinion (int p_notificacion)
{
        LePapeoGenNHibernate.EN.LePapeo.OpinionEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionEN self where select noti.Opinion FROM NotificacionEN as noti where noti.id = :p_notificacion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionENgetOpinionHQL");
                query.SetParameter ("p_notificacion", p_notificacion);


                result = query.UniqueResult<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
