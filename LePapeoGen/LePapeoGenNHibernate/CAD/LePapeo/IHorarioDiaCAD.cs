
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IHorarioDiaCAD
{
HorarioDiaEN ReadOIDDefault (int id
                             );

void ModifyDefault (HorarioDiaEN horarioDia);

System.Collections.Generic.IList<HorarioDiaEN> ReadAllDefault (int first, int size);



int New_ (HorarioDiaEN horarioDia);

void Modify (HorarioDiaEN horarioDia);


void Destroy (int id
              );


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.HorarioDiaEN> GetHorariosDiaFromHorarioSemana (int p_horarioSemana);


HorarioDiaEN ReadOID (int id
                      );


System.Collections.Generic.IList<HorarioDiaEN> ReadAll (int first, int size);
}
}
