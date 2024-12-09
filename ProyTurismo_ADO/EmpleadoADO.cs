using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using ProyTurismo_BE;

namespace ProyTurismo_ADO
{
    public class EmpleadoADO
    {
        // Método para listar empleados por ID, nombre, apellido, estado, etc.
        public List<EmpleadoBE> ListarEmpleados(string idEmpleado, string nombre, string apellido, string dni, string estado)
        {
            try
            {
                // Instanciar el contexto de la base de datos
                ProyectoTurismoEntities db = new ProyectoTurismoEntities();

                // Lista para almacenar los resultados
                List<EmpleadoBE> listaEmpleados = new List<EmpleadoBE>();

                // Convertir idEmpleado de string a int, si es posible
                int? idEmpleadoInt = null;
                if (int.TryParse(idEmpleado, out int result))
                {
                    idEmpleadoInt = result;
                }

                // Consulta LINQ para obtener los empleados
                var query = (from empleado in db.Tb_Empleado
                             where (idEmpleadoInt == null || empleado.ID_Empleado == idEmpleadoInt) &&
                                   (string.IsNullOrEmpty(nombre) || empleado.Nom_Emp.Contains(nombre)) &&
                                   (string.IsNullOrEmpty(apellido) || empleado.Ape_Emp.Contains(apellido)) &&
                                   (string.IsNullOrEmpty(dni) || empleado.Dni_Emp == dni) &&
                                   (string.IsNullOrEmpty(estado) || empleado.Estado == estado)
                             select new
                             {
                                 empleado.ID_Empleado,
                                 empleado.Nom_Emp,
                                 empleado.Ape_Emp,
                                 empleado.Dni_Emp,
                                 empleado.Tel_Emp,
                                 empleado.Email_Emp,
                                 empleado.Rol_Emp,
                                 empleado.Supervisor_ID,
                                 empleado.Fec_Reg,
                                 empleado.Fec_ult_mod,
                                 empleado.Estado
                             }).ToList();

                // Mapear los resultados de la consulta a la lista de objetos EmpleadoBE
                foreach (var resultado in query)
                {
                    EmpleadoBE empleado = new EmpleadoBE
                    {
                        ID_Empleado = resultado.ID_Empleado,
                        Nom_Emp = resultado.Nom_Emp,
                        Ape_Emp = resultado.Ape_Emp,
                        Dni_Emp = resultado.Dni_Emp,
                        Tel_Emp = resultado.Tel_Emp,
                        Email_Emp = resultado.Email_Emp,
                        Rol_Emp = resultado.Rol_Emp,
                        Supervisor_ID = resultado.Supervisor_ID, // Nullable int
                        Fec_Reg = resultado.Fec_Reg,  // Nullable DateTime
                        Fec_ult_mod = resultado.Fec_ult_mod, // Nullable DateTime
                        Estado = resultado.Estado
                    };

                    listaEmpleados.Add(empleado);
                }

                return listaEmpleados;
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al consultar los empleados: " + ex.Message);
            }
        }

        // Método para obtener un empleado por su ID
        public EmpleadoBE ObtenerEmpleadoPorID(string idEmpleado)
        {
            try
            {
                ProyectoTurismoEntities db = new ProyectoTurismoEntities();

                // Convertir idEmpleado de string a int, si es posible
                int? idEmpleadoInt = null;
                if (int.TryParse(idEmpleado, out int result))
                {
                    idEmpleadoInt = result;
                }

                var resultado = (from empleado in db.Tb_Empleado
                                 where empleado.ID_Empleado == idEmpleadoInt
                                 select new
                                 {
                                     empleado.ID_Empleado,
                                     empleado.Nom_Emp,
                                     empleado.Ape_Emp,
                                     empleado.Dni_Emp,
                                     empleado.Tel_Emp,
                                     empleado.Email_Emp,
                                     empleado.Rol_Emp,
                                     empleado.Supervisor_ID,
                                     empleado.Fec_Reg,
                                     empleado.Fec_ult_mod,
                                     empleado.Estado
                                 }).FirstOrDefault();

                if (resultado != null)
                {
                    return new EmpleadoBE
                    {
                        ID_Empleado = resultado.ID_Empleado,
                        Nom_Emp = resultado.Nom_Emp,
                        Ape_Emp = resultado.Ape_Emp,
                        Dni_Emp = resultado.Dni_Emp,
                        Tel_Emp = resultado.Tel_Emp,
                        Email_Emp = resultado.Email_Emp,
                        Rol_Emp = resultado.Rol_Emp,
                        Supervisor_ID = resultado.Supervisor_ID, // Nullable int
                        Fec_Reg = resultado.Fec_Reg,  // Nullable DateTime
                        Fec_ult_mod = resultado.Fec_ult_mod, // Nullable DateTime
                        Estado = resultado.Estado
                    };
                }
                else
                {
                    return null; // Si no se encuentra el empleado
                }
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al obtener el empleado por ID: " + ex.Message);
            }
        }

        // Método para contar empleados por estado
        public int ContarEmpleadosPorEstado(string estado)
        {
            try
            {
                ProyectoTurismoEntities db = new ProyectoTurismoEntities();

                var query = (from empleado in db.Tb_Empleado
                             where empleado.Estado == estado
                             select empleado).Count();

                return query;
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al contar los empleados por estado: " + ex.Message);
            }
        }
    }
}
