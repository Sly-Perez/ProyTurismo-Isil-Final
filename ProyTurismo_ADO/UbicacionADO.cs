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

        public List<UbicacionFacturacionBE> ListarFacturacionUbicacion()
        {
            try
            {
                ProyectoTurismoEntities TurismoBaseDatos = new ProyectoTurismoEntities();

                List<UbicacionFacturacionBE> objListaUbicacionFacturacionBE = new List<UbicacionFacturacionBE>();

                var query = (
                            (from miUbicacion in TurismoBaseDatos.Tb_Ubicacion
                             join miTour in TurismoBaseDatos.Tb_Tour
                             on miUbicacion.ID_Ubicacion equals miTour.ID_Ubicacion
                             join miReserva in TurismoBaseDatos.Tb_Reserva
                             on miTour.ID_Tour equals miReserva.ID_Tour
                             join miFactura in TurismoBaseDatos.Tb_Factura
                             on miReserva.ID_Reserva equals miFactura.ID_Reserva
                             group new { miFactura.Total, miReserva.ID_Reserva } by miUbicacion.Departamento into departamentoGroup
                             select new
                             {
                                 Departamento = departamentoGroup.Key,
                                 MontoTotalGenerado = departamentoGroup.Sum(miFactura => miFactura.Total),
                                 CantidadTotalReservas = departamentoGroup.Count()
                             }).ToList()
                            );

                foreach (var resultado in query)
                {
                    UbicacionFacturacionBE objUbicacionFacturacionBE = new UbicacionFacturacionBE();

                    objUbicacionFacturacionBE.Departamento = resultado.Departamento;
                    objUbicacionFacturacionBE.MontoTotalGenerado = Convert.ToSingle(resultado.MontoTotalGenerado);
                    objUbicacionFacturacionBE.CantidadReservas = resultado.CantidadTotalReservas;

                    objListaUbicacionFacturacionBE.Add(objUbicacionFacturacionBE);
                }

                return objListaUbicacionFacturacionBE;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

    }
}
