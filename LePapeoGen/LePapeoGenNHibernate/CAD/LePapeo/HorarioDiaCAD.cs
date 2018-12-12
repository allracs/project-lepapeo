
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
 * Clase HorarioDia:
 *
 */

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial class HorarioDiaCAD : BasicCAD, IHorarioDiaCAD
{
public HorarioDiaCAD() : base ()
{
}

public HorarioDiaCAD(ISession sessionAux) : base (sessionAux)
{
}



public HorarioDiaEN ReadOIDDefault (int id
                                    )
{
        HorarioDiaEN horarioDiaEN = null;

        try
        {
                SessionInitializeTransaction ();
                horarioDiaEN = (HorarioDiaEN)session.Get (typeof(HorarioDiaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horarioDiaEN;
}

public System.Collections.Generic.IList<HorarioDiaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<HorarioDiaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(HorarioDiaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<HorarioDiaEN>();
                        else
                                result = session.CreateCriteria (typeof(HorarioDiaEN)).List<HorarioDiaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (HorarioDiaEN horarioDia)
{
        try
        {
                SessionInitializeTransaction ();
                HorarioDiaEN horarioDiaEN = (HorarioDiaEN)session.Load (typeof(HorarioDiaEN), horarioDia.Id);

                horarioDiaEN.Hora_ini_am = horarioDia.Hora_ini_am;


                horarioDiaEN.Hora_fin_am = horarioDia.Hora_fin_am;


                horarioDiaEN.Hora_ini_pm = horarioDia.Hora_ini_pm;


                horarioDiaEN.Hora_fin_pm = horarioDia.Hora_fin_pm;


                horarioDiaEN.Dia = horarioDia.Dia;


                session.Update (horarioDiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (HorarioDiaEN horarioDia)
{
        try
        {
                SessionInitializeTransaction ();
                if (horarioDia.HorarioSemana != null) {
                        // Argumento OID y no colección.
                        horarioDia.HorarioSemana = (LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN)session.Load (typeof(LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN), horarioDia.HorarioSemana.Id);

                        horarioDia.HorarioSemana.HorarioDia
                        .Add (horarioDia);
                }

                session.Save (horarioDia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horarioDia.Id;
}

public void Modify (HorarioDiaEN horarioDia)
{
        try
        {
                SessionInitializeTransaction ();
                HorarioDiaEN horarioDiaEN = (HorarioDiaEN)session.Load (typeof(HorarioDiaEN), horarioDia.Id);

                horarioDiaEN.Hora_ini_am = horarioDia.Hora_ini_am;


                horarioDiaEN.Hora_fin_am = horarioDia.Hora_fin_am;


                horarioDiaEN.Hora_ini_pm = horarioDia.Hora_ini_pm;


                horarioDiaEN.Hora_fin_pm = horarioDia.Hora_fin_pm;


                horarioDiaEN.Dia = horarioDia.Dia;

                session.Update (horarioDiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
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
                HorarioDiaEN horarioDiaEN = (HorarioDiaEN)session.Load (typeof(HorarioDiaEN), id);
                session.Delete (horarioDiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> GetHorariosDiaFromHorarioSemana (int p_horarioSemana)
{
        System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM HorarioDiaEN self where FROM HorarioDiaEN as hd where hd.HorarioSemana.Id= :p_horarioSemana";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("HorarioDiaENgetHorariosDiaFromHorarioSemanaHQL");
                query.SetParameter ("p_horarioSemana", p_horarioSemana);

                result = query.List<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<HorarioDiaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<HorarioDiaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(HorarioDiaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<HorarioDiaEN>();
                else
                        result = session.CreateCriteria (typeof(HorarioDiaEN)).List<HorarioDiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadOID
//Con e: HorarioDiaEN
public HorarioDiaEN ReadOID (int id
                             )
{
        HorarioDiaEN horarioDiaEN = null;

        try
        {
                SessionInitializeTransaction ();
                horarioDiaEN = (HorarioDiaEN)session.Get (typeof(HorarioDiaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is LePapeoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new LePapeoGenNHibernate.Exceptions.DataLayerException ("Error in HorarioDiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horarioDiaEN;
}
}
}
