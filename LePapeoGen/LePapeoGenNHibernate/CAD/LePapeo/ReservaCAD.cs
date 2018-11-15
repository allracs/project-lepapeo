
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
 * Clase Reserva:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class ReservaCAD : BasicCAD, IReservaCAD
{
public ReservaCAD() : base ()
{
}

public ReservaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ReservaEN ReadOIDDefault (int id
                                 )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReservaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                        else
                                result = session.CreateCriteria (typeof(ReservaEN)).List<ReservaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaEN reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), reserva.Id);



                reservaEN.Comensales = reserva.Comensales;


                reservaEN.Estado = reserva.Estado;


                reservaEN.Finalizada = reserva.Finalizada;


                reservaEN.Fecha_hora = reserva.Fecha_hora;



                reservaEN.Fecha_solicitud = reserva.Fecha_solicitud;

                session.Update (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                if (reserva.Registrado != null) {
                        // Argumento OID y no colección.
                        reserva.Registrado = (LePapeoGenNHibernate.EN.LePapeo.RegistradoEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.RegistradoEN), reserva.Registrado.Id);

                        reserva.Registrado.Reserva
                        .Add (reserva);
                }
                if (reserva.Restaurante != null) {
                        // Argumento OID y no colección.
                        reserva.Restaurante = (LePapeoGenNHibernate.EN.LePapeo.RestauranteEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.RestauranteEN), reserva.Restaurante.Id);

                        reserva.Restaurante.Reserva_0
                        .Add (reserva);
                }

                session.Save (reserva);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reserva.Id;
}

public void Modify (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaEN reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), reserva.Id);

                reservaEN.Comensales = reserva.Comensales;


                reservaEN.Estado = reserva.Estado;


                reservaEN.Finalizada = reserva.Finalizada;


                reservaEN.Fecha_hora = reserva.Fecha_hora;


                reservaEN.Fecha_solicitud = reserva.Fecha_solicitud;

                session.Update (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
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
                ReservaEN reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), id);
                session.Delete (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void CambiarEstado (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaEN reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), reserva.Id);

                reservaEN.Estado = reserva.Estado;

                session.Update (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: ReservaEN
public ReservaEN ReadOID (int id
                          )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReservaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                else
                        result = session.CreateCriteria (typeof(ReservaEN)).List<ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistrado (int p_registrado)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaEN self where FROM ReservaEN as res where res.Registrado= :p_registrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaENgetReservasFromRegistradoHQL");
                query.SetParameter ("p_registrado", p_registrado);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestaurante (int p_restaurante)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaEN self where FROM ReservaEN as res where res.Restaurante.Id = :p_restaurante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaENgetReservasFromRestauranteHQL");
                query.SetParameter ("p_restaurante", p_restaurante);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteYRegistrado (int p_registrado, int p_restaurante)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaEN self where FROM ReservaEN as res where res.Registrado.Id = :p_registrado and res.Restaurante.Id  = :p_restaurante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaENgetReservasFromRestauranteYRegistradoHQL");
                query.SetParameter ("p_registrado", p_registrado);
                query.SetParameter ("p_restaurante", p_restaurante);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistradoFinal (int p_registrado, bool ? p_finalizada)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaEN self where select res FROM ReservaEN as res where res.Finalizada = :p_finalizada and res.Registrado = :p_registrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaENgetReservasFromRegistradoFinalHQL");
                query.SetParameter ("p_registrado", p_registrado);
                query.SetParameter ("p_finalizada", p_finalizada);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteFinal (int p_restaurante, bool ? p_finalizada)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaEN self where FROM ReservaEN as res where res.Finalizada = :p_finalizada and res.Restaurante = :p_restaurante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaENgetReservasFromRestauranteFinalHQL");
                query.SetParameter ("p_restaurante", p_restaurante);
                query.SetParameter ("p_finalizada", p_finalizada);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistradoByFechaHora (int p_registrado, Nullable<DateTime> p_fecha_hora)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaEN self where FROM ReservaEN as res where res.Fecha_hora = :p_fecha_hora and res.Registrado = :p_registrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaENgetReservasFromRegistradoByFechaHoraHQL");
                query.SetParameter ("p_registrado", p_registrado);
                query.SetParameter ("p_fecha_hora", p_fecha_hora);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteByFechaHora (int p_restaurante, Nullable<DateTime> p_fecha_hora)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaEN self where FROM ReservaEN as res where res.Fecha_hora = :p_fecha_hora and res.Restaurante = :p_restaurante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaENgetReservasFromRestauranteByFechaHoraHQL");
                query.SetParameter ("p_restaurante", p_restaurante);
                query.SetParameter ("p_fecha_hora", p_fecha_hora);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void CambiarFinalizacion (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaEN reservaEN = (ReservaEN)session.Load (typeof(ReservaEN), reserva.Id);

                reservaEN.Finalizada = reserva.Finalizada;

                session.Update (reservaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in ReservaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
