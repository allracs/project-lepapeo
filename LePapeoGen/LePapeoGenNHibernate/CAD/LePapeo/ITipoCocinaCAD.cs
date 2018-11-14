
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface ITipoCocinaCAD
{
TipoCocinaEN ReadOIDDefault (string tipo
                             );

void ModifyDefault (TipoCocinaEN tipoCocina);

System.Collections.Generic.IList<TipoCocinaEN> ReadAllDefault (int first, int size);



string New_ (TipoCocinaEN tipoCocina);

void Modify (TipoCocinaEN tipoCocina);


void Destroy (string tipo
              );
}
}
