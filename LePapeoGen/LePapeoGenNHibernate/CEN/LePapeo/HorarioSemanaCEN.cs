

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
 *      Definition of the class HorarioSemanaCEN
 *
 */
public partial class HorarioSemanaCEN
{
private IHorarioSemanaCAD _IHorarioSemanaCAD;

public HorarioSemanaCEN()
{
        this._IHorarioSemanaCAD = new HorarioSemanaCAD ();
}

public HorarioSemanaCEN(IHorarioSemanaCAD _IHorarioSemanaCAD)
{
        this._IHorarioSemanaCAD = _IHorarioSemanaCAD;
}

public IHorarioSemanaCAD get_IHorarioSemanaCAD ()
{
        return this._IHorarioSemanaCAD;
}

public int New_ ()
{
        HorarioSemanaEN horarioSemanaEN = null;
        int oid;

        //Initialized HorarioSemanaEN
        horarioSemanaEN = new HorarioSemanaEN ();
        //Call to HorarioSemanaCAD

        oid = _IHorarioSemanaCAD.New_ (horarioSemanaEN);
        return oid;
}

public void Modify (int p_HorarioSemana_OID)
{
        HorarioSemanaEN horarioSemanaEN = null;

        //Initialized HorarioSemanaEN
        horarioSemanaEN = new HorarioSemanaEN ();
        horarioSemanaEN.Id = p_HorarioSemana_OID;
        //Call to HorarioSemanaCAD

        _IHorarioSemanaCAD.Modify (horarioSemanaEN);
}

public void Destroy (int id
                     )
{
        _IHorarioSemanaCAD.Destroy (id);
}

public void AgregarHorarioDia (int p_HorarioSemana_OID, System.Collections.Generic.IList<int> p_horarioDia_OIDs)
{
        //Call to HorarioSemanaCAD

        _IHorarioSemanaCAD.AgregarHorarioDia (p_HorarioSemana_OID, p_horarioDia_OIDs);
}
}
}
