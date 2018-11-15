
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
 * Clase Registrado:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class RegistradoCAD : BasicCAD, IRegistradoCAD
{
public RegistradoCAD() : base ()
{
}

public RegistradoCAD(ISession sessionAux) : base (sessionAux)
{
}



public RegistradoEN ReadOIDDefault (int id
                                    )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RegistradoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RegistradoEN>();
                        else
                                result = session.CreateCriteria (typeof(RegistradoEN)).List<RegistradoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), registrado.Id);

                registradoEN.Nombre = registrado.Nombre;


                registradoEN.Apellidos = registrado.Apellidos;


                registradoEN.Fecha_nac = registrado.Fecha_nac;




                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (registrado);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registrado.Id;
}

public void Modify (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), registrado.Id);

                registradoEN.Email = registrado.Email;


                registradoEN.Pass = registrado.Pass;


                registradoEN.Fecha_inscripcion = registrado.Fecha_inscripcion;


                registradoEN.Nombre = registrado.Nombre;


                registradoEN.Apellidos = registrado.Apellidos;


                registradoEN.Fecha_nac = registrado.Fecha_nac;

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
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
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), id);
                session.Delete (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: RegistradoEN
public RegistradoEN ReadOID (int id
                             )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RegistradoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RegistradoEN>();
                else
                        result = session.CreateCriteria (typeof(RegistradoEN)).List<RegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AgregarDireccion (int p_Registrado_OID, int p_direccion_0_OID)
{
        LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registradoEN = null;
        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), p_Registrado_OID);
                registradoEN.Direccion_0 = (LePapeoGenNHibernate.EN.LePapeo.DireccionEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.DireccionEN), p_direccion_0_OID);

                registradoEN.Direccion_0.Registrado.Add (registradoEN);



                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesvincularDireccion (int p_Registrado_OID, int p_direccion_0_OID)
{
        try
        {
                SessionInitializeTransaction ();
                LePapeoGenNHibernate.EN.LePapeo.RegistradoEN registradoEN = null;
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), p_Registrado_OID);

                if (registradoEN.Direccion_0.Id == p_direccion_0_OID) {
                        registradoEN.Direccion_0 = null;
                }
                else
                        throw new ModelException ("The identifier " + p_direccion_0_OID + " in p_direccion_0_OID you are trying to unrelationer, doesn't exist in RegistradoEN");

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public LePapeoGenNHibernate.EN.LePapeo.DireccionEN GetDireccion (int p_registrado)
{
        LePapeoGenNHibernate.EN.LePapeo.DireccionEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RegistradoEN self where select res.Direccion_0 FROM RegistradoEN as res where res.id = :p_registrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RegistradoENgetDireccionHQL");
                query.SetParameter ("p_registrado", p_registrado);


                result = query.UniqueResult<LePapeoGenNHibernate.EN.LePapeo.DireccionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
