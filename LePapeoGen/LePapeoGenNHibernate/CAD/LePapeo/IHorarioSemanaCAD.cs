
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IHorarioSemanaCAD
{
HorarioSemanaEN ReadOIDDefault (int id
                                );

void ModifyDefault (HorarioSemanaEN horarioSemana);

System.Collections.Generic.IList<HorarioSemanaEN> ReadAllDefault (int first, int size);



int New_ (HorarioSemanaEN horarioSemana);

void Modify (HorarioSemanaEN horarioSemana);


void Destroy (int id
              );


void AgregarHorarioDia (int p_HorarioSemana_OID, System.Collections.Generic.IList<int> p_horarioDia_OIDs);
}
}
