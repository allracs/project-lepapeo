
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
 * Clase Opinion:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class OpinionCAD : BasicCAD, IOpinionCAD
{
public OpinionCAD() : base ()
{
}

public OpinionCAD(ISession sessionAux) : base (sessionAux)
{
}



public OpinionEN ReadOIDDefault (int id
                                 )
{
        OpinionEN opinionEN = null;

        try
        {
                SessionInitializeTransaction ();
                opinionEN = (OpinionEN)session.Get (typeof(OpinionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return opinionEN;
}

public System.Collections.Generic.IList<OpinionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<OpinionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(OpinionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<OpinionEN>();
                        else
                                result = session.CreateCriteria (typeof(OpinionEN)).List<OpinionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (OpinionEN opinion)
{
        try
        {
                SessionInitializeTransaction ();
                OpinionEN opinionEN = (OpinionEN)session.Load (typeof(OpinionEN), opinion.Id);

                opinionEN.Valoracion = opinion.Valoracion;


                opinionEN.Titulo = opinion.Titulo;


                opinionEN.Comentario = opinion.Comentario;





                opinionEN.Fecha = opinion.Fecha;

                session.Update (opinionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (OpinionEN opinion)
{
        try
        {
                SessionInitializeTransaction ();
                if (opinion.Registrado != null) {
                        // Argumento OID y no colección.
                        opinion.Registrado = (LePapeoGenNHibernate.EN.LePapeo.RegistradoEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.RegistradoEN), opinion.Registrado.Id);

                        opinion.Registrado.Opinion
                        .Add (opinion);
                }
                if (opinion.Restaurante != null) {
                        // Argumento OID y no colección.
                        opinion.Restaurante = (LePapeoGenNHibernate.EN.LePapeo.RestauranteEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.RestauranteEN), opinion.Restaurante.Id);

                        opinion.Restaurante.Opinion_0
                        .Add (opinion);
                }

                session.Save (opinion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return opinion.Id;
}

public void Modify (OpinionEN opinion)
{
        try
        {
                SessionInitializeTransaction ();
                OpinionEN opinionEN = (OpinionEN)session.Load (typeof(OpinionEN), opinion.Id);

                opinionEN.Valoracion = opinion.Valoracion;


                opinionEN.Titulo = opinion.Titulo;


                opinionEN.Comentario = opinion.Comentario;


                opinionEN.Fecha = opinion.Fecha;

                session.Update (opinionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
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
                OpinionEN opinionEN = (OpinionEN)session.Load (typeof(OpinionEN), id);
                session.Delete (opinionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: OpinionEN
public OpinionEN ReadOID (int id
                          )
{
        OpinionEN opinionEN = null;

        try
        {
                SessionInitializeTransaction ();
                opinionEN = (OpinionEN)session.Get (typeof(OpinionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return opinionEN;
}

public System.Collections.Generic.IList<OpinionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<OpinionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(OpinionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<OpinionEN>();
                else
                        result = session.CreateCriteria (typeof(OpinionEN)).List<OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistrado (int p_registrado)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM OpinionEN self where FROM OpinionEN as opi where opi.Registrado = :p_registrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("OpinionENgetOpinionsFromRegistradoHQL");
                query.SetParameter ("p_registrado", p_registrado);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRestaurante (int p_restaurante)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM OpinionEN self where FROM OpinionEN as opi where opi.Restaurante = :p_restaurante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("OpinionENgetOpinionsFromRestauranteHQL");
                query.SetParameter ("p_restaurante", p_restaurante);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoByValoracion (int p_registrado, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum ? p_valoracion)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM OpinionEN self where FROM OpinionEN as opi where opi.Registrado = :p_registrado and opi.Valoracion = :p_valoracion ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("OpinionENgetOpinionsFromRegistradoByValoracionHQL");
                query.SetParameter ("p_registrado", p_registrado);
                query.SetParameter ("p_valoracion", p_valoracion);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRestauranteByValoracion (int p_restaurante, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum ? p_valoracion)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM OpinionEN self where FROM OpinionEN as opi where opi.Restaurante = :p_restaurante and opi.Valoracion = :p_valoracion ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("OpinionENgetOpinionsFromRestauranteByValoracionHQL");
                query.SetParameter ("p_restaurante", p_restaurante);
                query.SetParameter ("p_valoracion", p_valoracion);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoYRestaurante (int p_restaurante, int p_registrado)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM OpinionEN self where from OpinionEN as opi where opi.Restaurante = :p_restaurante and opi.Registrado = :p_registrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("OpinionENgetOpinionsFromRegistradoYRestauranteHQL");
                query.SetParameter ("p_restaurante", p_restaurante);
                query.SetParameter ("p_registrado", p_registrado);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoYRestauranteByValoracion (int p_registrado, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum? p_valoracion, int p_restaurante)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM OpinionEN self where FROM OpinionEN as opi where opi.Restaurante = :p_restaurante and opi.Valoracion = :p_valoracion and opi.Registrado = :p_registrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("OpinionENgetOpinionsFromRegistradoYRestauranteByValoracionHQL");
                query.SetParameter ("p_registrado", p_registrado);
                query.SetParameter ("p_valoracion", p_valoracion);
                query.SetParameter ("p_restaurante", p_restaurante);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.OpinionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in OpinionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
