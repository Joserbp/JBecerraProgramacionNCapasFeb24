using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static (bool, string, ML.Estado, Exception) GetByIdPais(int IdPais)
        {
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasFeb24Entities context = new DL_EF.JBecerraProgramacionNCapasFeb24Entities())
                {
                    var estados = context.EstadoGetByIdPais(IdPais).ToList();
                    if (estados.Count > 0)
                    {
                        ML.Estado estado = new ML.Estado();
                        estado.Estados = new List<ML.Estado>();

                        foreach (var Objestado in estados)
                        {
                            ML.Estado estado1 = new ML.Estado();
                            estado1.IdEstado = Objestado.IdEstado;
                            estado1.Nombre = Objestado.Nombre;

                            estado.Estados.Add(estado1);

                        }

                        return (true, null, estado, null);

                    }
                    else
                    {
                        return (false, "No hay datos en la tabla", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}
