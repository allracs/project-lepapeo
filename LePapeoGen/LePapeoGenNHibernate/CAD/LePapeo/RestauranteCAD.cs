
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
 * Clase Restaurante:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class RestauranteCAD : BasicCAD, IRestauranteCAD
{
public RestauranteCAD() : base ()
{
}

public RestauranteCAD(ISession sessionAux) : base (sessionAux)
{
}



public RestauranteEN ReadOIDDefault (int id
                                     )
{
        RestauranteEN restauranteEN = null;

        try
        {
                SessionInitializeTransaction ();
                restauranteEN = (RestauranteEN)session.Get (typeof(RestauranteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restauranteEN;
}

public System.Collections.Generic.IList<RestauranteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RestauranteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RestauranteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RestauranteEN>();
                        else
                                result = session.CreateCriteria (typeof(RestauranteEN)).List<RestauranteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RestauranteEN restaurante)
{
        try
        {
                SessionInitializeTransaction ();
                RestauranteEN restauranteEN = (RestauranteEN)session.Load (typeof(RestauranteEN), restaurante.Id);

                restauranteEN.Nombre = restaurante.Nombre;


                restauranteEN.Fecha_apertura = restaurante.Fecha_apertura;







                restauranteEN.Max_comen = restaurante.Max_comen;


                restauranteEN.Current_comen = restaurante.Current_comen;


                restauranteEN.Precio_medio = restaurante.Precio_medio;


                restauranteEN.Descripcion = restaurante.Descripcion;


                restauranteEN.Menu = restaurante.Menu;

                session.Update (restauranteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RestauranteEN restaurante)
{
        try
        {
                SessionInitializeTransaction ();
                if (restaurante.TipoCocina != null) {
                        // Argumento OID y no colección.
                        restaurante.TipoCocina = (LePapeoGenNHibernate.EN.LePapeo.TipoCocinaEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.TipoCocinaEN), restaurante.TipoCocina.Tipo);

                        restaurante.TipoCocina.Restaurante
                        .Add (restaurante);
                }

                session.Save (restaurante);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restaurante.Id;
}

public void Modify (RestauranteEN restaurante)
{
        try
        {
                SessionInitializeTransaction ();
                RestauranteEN restauranteEN = (RestauranteEN)session.Load (typeof(RestauranteEN), restaurante.Id);

                restauranteEN.Email = restaurante.Email;


                restauranteEN.Pass = restaurante.Pass;


                restauranteEN.Fecha_inscripcion = restaurante.Fecha_inscripcion;


                restauranteEN.Nombre = restaurante.Nombre;


                restauranteEN.Fecha_apertura = restaurante.Fecha_apertura;


                restauranteEN.Max_comen = restaurante.Max_comen;


                restauranteEN.Current_comen = restaurante.Current_comen;


                restauranteEN.Precio_medio = restaurante.Precio_medio;


                restauranteEN.Descripcion = restaurante.Descripcion;


                restauranteEN.Menu = restaurante.Menu;

                session.Update (restauranteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
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
                RestauranteEN restauranteEN = (RestauranteEN)session.Load (typeof(RestauranteEN), id);
                session.Delete (restauranteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: RestauranteEN
public RestauranteEN ReadOID (int id
                              )
{
        RestauranteEN restauranteEN = null;

        try
        {
                SessionInitializeTransaction ();
                restauranteEN = (RestauranteEN)session.Get (typeof(RestauranteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restauranteEN;
}

public System.Collections.Generic.IList<RestauranteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RestauranteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RestauranteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RestauranteEN>();
                else
                        result = session.CreateCriteria (typeof(RestauranteEN)).List<RestauranteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AgregarDireccion (int p_Restaurante_OID, int p_direccion_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restauranteEN = null;
        try
        {
                SessionInitializeTransaction ();
                restauranteEN = (RestauranteEN)session.Load (typeof(RestauranteEN), p_Restaurante_OID);
                restauranteEN.Direccion = (LePapeoGenNHibernate.EN.LePapeo.DireccionEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.DireccionEN), p_direccion_OID);

                restauranteEN.Direccion.Restaurante = restauranteEN;




                session.Update (restauranteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesvincularDireccion (int p_Restaurante_OID, int p_direccion_OID)
{
        try
        {
                SessionInitializeTransaction ();
                LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restauranteEN = null;
                restauranteEN = (RestauranteEN)session.Load (typeof(RestauranteEN), p_Restaurante_OID);

                if (restauranteEN.Direccion.Id == p_direccion_OID) {
                        restauranteEN.Direccion = null;
                        LePapeoGenNHibernate.EN.LePapeo.DireccionEN direccionEN = (LePapeoGenNHibernate.EN.LePapeo.DireccionEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.DireccionEN), p_direccion_OID);
                        direccionEN.Restaurante = null;
                }
                else
                        throw new ModelException ("The identifier " + p_direccion_OID + " in p_direccion_OID you are trying to unrelationer, doesn't exist in RestauranteEN");

                session.Update (restauranteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> BuscarRestaurante (string p_cadena)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RestauranteEN self where FROM RestauranteEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RestauranteENbuscarRestauranteHQL");
                query.SetParameter ("p_cadena", p_cadena);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AgregarHorarioSemana (int p_Restaurante_OID, int p_horarioSemana_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restauranteEN = null;
        try
        {
                SessionInitializeTransaction ();
                restauranteEN = (RestauranteEN)session.Load (typeof(RestauranteEN), p_Restaurante_OID);
                restauranteEN.HorarioSemana = (LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN), p_horarioSemana_OID);

                restauranteEN.HorarioSemana.Restaurante.Add (restauranteEN);



                session.Update (restauranteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesvincularHorarioSemana (int p_Restaurante_OID, int p_horarioSemana_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.RestauranteEN restauranteEN = null;
        try
        {
                SessionInitializeTransaction ();
                restauranteEN = (RestauranteEN)session.Load (typeof(RestauranteEN), p_Restaurante_OID);
                restauranteEN.HorarioSemana = (LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN), p_horarioSemana_OID);

                restauranteEN.HorarioSemana.Restaurante.Add (restauranteEN);



                session.Update (restauranteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN GetHorarioSemana (int p_restaurante)
{
        LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RestauranteEN self where select res.HorarioSemana FROM RestauranteEN as res where res.id = :p_restaurante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RestauranteENgetHorarioSemanaHQL");
                query.SetParameter ("p_restaurante", p_restaurante);


                result = query.UniqueResult<LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public LePapeoGenNHibernate.EN.LePapeo.DireccionEN GetDireccion (int p_restaurante)
{
        LePapeoGenNHibernate.EN.LePapeo.DireccionEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RestauranteEN self where select res.Direccion FROM RestauranteEN as res where res.id = :p_restaurante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RestauranteENgetDireccionHQL");
                query.SetParameter ("p_restaurante", p_restaurante);


                result = query.UniqueResult<LePapeoGenNHibernate.EN.LePapeo.DireccionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RestauranteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
