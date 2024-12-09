using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using ProyTurismo_BE;

namespace ProyTurismo_ADO
{
    public class UbicacionADO
    {
        public List<String> ListarDepartamentosUbicaciones()
        {
            try
            {
                ProyectoTurismoEntities TurismoBaseDatos = new ProyectoTurismoEntities();

                List<String> objListaDepartamentos = new List<string>();

                var query = (
                            (from miUbicacion in TurismoBaseDatos.Tb_Ubicacion
                             group miUbicacion by miUbicacion.Departamento
                             into departamentoGroup
                             select new
                             {
                                 Departamento = departamentoGroup.Key,
                                 Visitas = departamentoGroup.Count()
                             }).ToList()
                            );

                objListaDepartamentos.Add("Todos");
                foreach (var resultado in query)
                {
                    objListaDepartamentos.Add(resultado.Departamento);
                }

                return objListaDepartamentos;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
