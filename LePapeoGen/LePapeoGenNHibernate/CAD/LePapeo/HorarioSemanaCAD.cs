
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
 * Clase HorarioSemana:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class HorarioSemanaCAD : BasicCAD, IHorarioSemanaCAD
{
public HorarioSemanaCAD() : base ()
{
}

public HorarioSemanaCAD(ISession sessionAux) : base (sessionAux)
{
}



public HorarioSemanaEN ReadOIDDefault (int id
                                       )
{
        HorarioSemanaEN horarioSemanaEN = null;

        try
        {
                SessionInitializeTransaction ();
                horarioSemanaEN = (HorarioSemanaEN)session.Get (typeof(HorarioSemanaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horarioSemanaEN;
}

public System.Collections.Generic.IList<HorarioSemanaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<HorarioSemanaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(HorarioSemanaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<HorarioSemanaEN>();
                        else
                                result = session.CreateCriteria (typeof(HorarioSemanaEN)).List<HorarioSemanaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (HorarioSemanaEN horarioSemana)
{
        try
        {
                SessionInitializeTransaction ();
                HorarioSemanaEN horarioSemanaEN = (HorarioSemanaEN)session.Load (typeof(HorarioSemanaEN), horarioSemana.Id);


                session.Update (horarioSemanaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (HorarioSemanaEN horarioSemana)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (horarioSemana);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horarioSemana.Id;
}

public void Modify (HorarioSemanaEN horarioSemana)
{
        try
        {
                SessionInitializeTransaction ();
                HorarioSemanaEN horarioSemanaEN = (HorarioSemanaEN)session.Load (typeof(HorarioSemanaEN), horarioSemana.Id);
                session.Update (horarioSemanaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
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
                HorarioSemanaEN horarioSemanaEN = (HorarioSemanaEN)session.Load (typeof(HorarioSemanaEN), id);
                session.Delete (horarioSemanaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AgregarHorarioDia (int p_HorarioSemana_OID, System.Collections.Generic.IList<int> p_horarioDia_OIDs)
{
        LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN horarioSemanaEN = null;
        try
        {
                SessionInitializeTransaction ();
                horarioSemanaEN = (HorarioSemanaEN)session.Load (typeof(HorarioSemanaEN), p_HorarioSemana_OID);
                LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN horarioDiaENAux = null;
                if (horarioSemanaEN.HorarioDia == null) {
                        horarioSemanaEN.HorarioDia = new System.Collections.Generic.List<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN>();
                }

                foreach (int item in p_horarioDia_OIDs) {
                        horarioDiaENAux = new LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN ();
                        horarioDiaENAux = (LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN), item);
                        horarioDiaENAux.HorarioSemana = horarioSemanaEN;

                        horarioSemanaEN.HorarioDia.Add (horarioDiaENAux);
                }


                session.Update (horarioSemanaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<HorarioSemanaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<HorarioSemanaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(HorarioSemanaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<HorarioSemanaEN>();
                else
                        result = session.CreateCriteria (typeof(HorarioSemanaEN)).List<HorarioSemanaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadOID
//Con e: HorarioSemanaEN
public HorarioSemanaEN ReadOID (int id
                                )
{
        HorarioSemanaEN horarioSemanaEN = null;

        try
        {
                SessionInitializeTransaction ();
                horarioSemanaEN = (HorarioSemanaEN)session.Get (typeof(HorarioSemanaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioSemanaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horarioSemanaEN;
}
}
}
