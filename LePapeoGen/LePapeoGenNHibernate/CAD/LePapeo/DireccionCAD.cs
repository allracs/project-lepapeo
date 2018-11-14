
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
 * Clase Direccion:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class DireccionCAD : BasicCAD, IDireccionCAD
{
public DireccionCAD() : base ()
{
}

public DireccionCAD(ISession sessionAux) : base (sessionAux)
{
}



public DireccionEN ReadOIDDefault (int id
                                   )
{
        DireccionEN direccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                direccionEN = (DireccionEN)session.Get (typeof(DireccionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccionEN;
}

public System.Collections.Generic.IList<DireccionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DireccionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<DireccionEN>();
                        else
                                result = session.CreateCriteria (typeof(DireccionEN)).List<DireccionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEN direccionEN = (DireccionEN)session.Load (typeof(DireccionEN), direccion.Id);

                direccionEN.Cod_pos = direccion.Cod_pos;


                direccionEN.Calle = direccion.Calle;




                direccionEN.Numero = direccion.Numero;


                direccionEN.Pos_x = direccion.Pos_x;


                direccionEN.Pos_y = direccion.Pos_y;


                session.Update (direccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();
                if (direccion.Ciudad != null) {
                        // Argumento OID y no colección.
                        direccion.Ciudad = (LePapeoGenNHibernate.EN.LePapeo.CiudadEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.CiudadEN), direccion.Ciudad.Nombre);

                        direccion.Ciudad.Direccion
                        .Add (direccion);
                }

                session.Save (direccion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccion.Id;
}

public void Modify (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEN direccionEN = (DireccionEN)session.Load (typeof(DireccionEN), direccion.Id);

                direccionEN.Cod_pos = direccion.Cod_pos;


                direccionEN.Calle = direccion.Calle;


                direccionEN.Numero = direccion.Numero;


                direccionEN.Pos_x = direccion.Pos_x;


                direccionEN.Pos_y = direccion.Pos_y;

                session.Update (direccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
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
                DireccionEN direccionEN = (DireccionEN)session.Load (typeof(DireccionEN), id);
                session.Delete (direccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
