
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IOpinionCAD
{
OpinionEN ReadOIDDefault (int id
                          );

void ModifyDefault (OpinionEN opinion);

System.Collections.Generic.IList<OpinionEN> ReadAllDefault (int first, int size);



int New_ (OpinionEN opinion);

void Modify (OpinionEN opinion);


void Destroy (int id
              );


OpinionEN ReadOID (int id
                   );


System.Collections.Generic.IList<OpinionEN> ReadAll (int first, int size);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistrado (int p_registrado);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRestaurante (int p_restaurante);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoByValoracion (int p_registrado, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum ? p_valoracion);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRestauranteByValoracion (int p_restaurante, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum ? p_valoracion);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoYRestaurante (int p_restaurante, int p_registrado);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoYRestauranteByValoracion (int p_registrado, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum? p_valoracion, int p_restaurante);
}
}
