using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static (bool,string,ML.Pais,Exception) GetAll()
        {
            try
            {
                using(DL_EF.JBecerraProgramacionNCapasFeb24Entities context = new DL_EF.JBecerraProgramacionNCapasFeb24Entities())
                {
                    var paises = context.PaisGetAll().ToList();
                    if(paises.Count > 0)
                    {
                        ML.Pais pais = new ML.Pais();
                        pais.Paises = new List<ML.Pais>();

                        foreach(var Objpais in paises)
                        {
                            ML.Pais pais1 = new ML.Pais();
                            pais1.IdPais = Objpais.IdPais;
                            pais1.Nombre = Objpais.Nombre;

                            pais.Paises.Add(pais1);

                        }

                        return (true, null, pais, null);

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
