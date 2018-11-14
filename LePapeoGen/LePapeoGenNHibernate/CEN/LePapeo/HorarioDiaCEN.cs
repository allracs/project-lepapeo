

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.Exceptions;

using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;


namespace LePapeoGenNHibernate.CEN.LePapeo
{
/*
 *      Definition of the class HorarioDiaCEN
 *
 */
public partial class HorarioDiaCEN
{
private IHorarioDiaCAD _IHorarioDiaCAD;

public HorarioDiaCEN()
{
        this._IHorarioDiaCAD = new HorarioDiaCAD ();
}

public HorarioDiaCEN(IHorarioDiaCAD _IHorarioDiaCAD)
{
        this._IHorarioDiaCAD = _IHorarioDiaCAD;
}

public IHorarioDiaCAD get_IHorarioDiaCAD ()
{
        return this._IHorarioDiaCAD;
}

public int New_ (Nullable<DateTime> p_hora_ini_am, Nullable<DateTime> p_hora_fin_am, Nullable<DateTime> p_hora_ini_pm, Nullable<DateTime> p_hora_fin_pm, LePapeoGenNHibernate.Enumerated.LePapeo.DiaSemanaEnum p_dia, int p_horarioSemana)
{
        HorarioDiaEN horarioDiaEN = null;
        int oid;

        //Initialized HorarioDiaEN
        horarioDiaEN = new HorarioDiaEN ();
        horarioDiaEN.Hora_ini_am = p_hora_ini_am;

        horarioDiaEN.Hora_fin_am = p_hora_fin_am;

        horarioDiaEN.Hora_ini_pm = p_hora_ini_pm;

        horarioDiaEN.Hora_fin_pm = p_hora_fin_pm;

        horarioDiaEN.Dia = p_dia;


        if (p_horarioSemana != -1) {
                // El argumento p_horarioSemana -> Property horarioSemana es oid = false
                // Lista de oids id
                horarioDiaEN.HorarioSemana = new LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN ();
                horarioDiaEN.HorarioSemana.Id = p_horarioSemana;
        }

        //Call to HorarioDiaCAD

        oid = _IHorarioDiaCAD.New_ (horarioDiaEN);
        return oid;
}

public void Modify (int p_HorarioDia_OID, Nullable<DateTime> p_hora_ini_am, Nullable<DateTime> p_hora_fin_am, Nullable<DateTime> p_hora_ini_pm, Nullable<DateTime> p_hora_fin_pm, LePapeoGenNHibernate.Enumerated.LePapeo.DiaSemanaEnum p_dia)
{
        HorarioDiaEN horarioDiaEN = null;

        //Initialized HorarioDiaEN
        horarioDiaEN = new HorarioDiaEN ();
        horarioDiaEN.Id = p_HorarioDia_OID;
        horarioDiaEN.Hora_ini_am = p_hora_ini_am;
        horarioDiaEN.Hora_fin_am = p_hora_fin_am;
        horarioDiaEN.Hora_ini_pm = p_hora_ini_pm;
        horarioDiaEN.Hora_fin_pm = p_hora_fin_pm;
        horarioDiaEN.Dia = p_dia;
        //Call to HorarioDiaCAD

        _IHorarioDiaCAD.Modify (horarioDiaEN);
}

public void Destroy (int id
                     )
{
        _IHorarioDiaCAD.Destroy (id);
}

public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> GetHorariosDiaFromHorarioSemana (int p_horarioSemana)
{
        return _IHorarioDiaCAD.GetHorariosDiaFromHorarioSemana (p_horarioSemana);
}
}
}
