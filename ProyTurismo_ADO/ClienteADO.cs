using ProyTurismo_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyTurismo_ADO;

namespace ProyTurismo_ADO
{
    public class ClienteADO
    {
       
        public List<FacturaClienteBE> ListarFacturacionClienteEntreFechasYEstado(int idCliente, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            try
            {
                List<FacturaClienteBE> listaFacturas = new List<FacturaClienteBE>();

                using (ProyectoTurismoEntities db = new ProyectoTurismoEntities())
                {
                    
                    var query = db.usp_ListarClientesConFacturas_DesdeVista(idCliente, estado);

                    foreach (var item in query)
                    {
                        FacturaClienteBE factura = new FacturaClienteBE
                        {
                            IdCliente = item.ID_Cliente,
                            Nombre = item.NombreCompleto,
                            IdFactura = item.ID_Factura.HasValue ? item.ID_Factura.Value : 0,
                            FechaEmision = item.FechaEmision.HasValue ? item.FechaEmision.Value : default(DateTime),
                            Total = item.MontoTotal,
                            EstadoFactura = item.Estado_Cliente
                        };
                        listaFacturas.Add(factura);
                    }
                }

                return listaFacturas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar facturación: " + ex.Message);
            }
        }

       
        public List<FacturaClienteBE> ListarFacturacionClientePorEstado(int idCliente, string estado)
        {
            try
            {
                List<FacturaClienteBE> listaFacturas = new List<FacturaClienteBE>();

                using (ProyectoTurismoEntities db = new ProyectoTurismoEntities())
                {
                    
                    var query = db.usp_ListarClientesConFacturas_DesdeVista(idCliente, estado);

                    foreach (var item in query)
                    {
                        FacturaClienteBE factura = new FacturaClienteBE
                        {
                            IdCliente = item.ID_Cliente,
                            Nombre = item.NombreCompleto,
                            IdFactura = item.ID_Factura.HasValue ? item.ID_Factura.Value : 0,
                            FechaEmision = item.FechaEmision.HasValue ? item.FechaEmision.Value : default(DateTime),
                            Total = item.MontoTotal,
                            EstadoFactura = item.Estado_Cliente
                        };
                        listaFacturas.Add(factura);
                    }
                }

                return listaFacturas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar facturación por estado: " + ex.Message);
            }
        }


        public List<FacturaClienteBE> ListarFacturacionClienteEntreFechas(int idCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<FacturaClienteBE> listaFacturas = new List<FacturaClienteBE>();

                using (ProyectoTurismoEntities db = new ProyectoTurismoEntities())
                {
                    
                    var query = db.usp_ListarClientesConFacturas_DesdeVista(idCliente, "");

                    foreach (var item in query)
                    {
                        if (item.FechaEmision >= fechaInicio && item.FechaEmision <= fechaFin)
                        {
                            FacturaClienteBE factura = new FacturaClienteBE
                            {
                                IdCliente = item.ID_Cliente,
                                Nombre = item.NombreCompleto,
                                IdFactura = item.ID_Factura.HasValue ? item.ID_Factura.Value : 0,
                                FechaEmision = item.FechaEmision.HasValue ? item.FechaEmision.Value : default(DateTime),
                                Total = item.MontoTotal,
                                EstadoFactura = item.Estado_Cliente
                            };
                            listaFacturas.Add(factura);
                        }
                    }
                }

                return listaFacturas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar facturación entre fechas: " + ex.Message);
            }
        }

        public FacturaClienteBE ObtenerUltimaFacturaCliente(int idCliente)
        {
            try
            {
                FacturaClienteBE factura = null;

                using (ProyectoTurismoEntities db = new ProyectoTurismoEntities())
                {
                  
                    var query = db.usp_ListarClientesConFacturas_DesdeVista(idCliente, "");

                    var ultimaFactura = query.OrderByDescending(f => f.FechaEmision).FirstOrDefault();

                    if (ultimaFactura != null)
                    {
                        factura = new FacturaClienteBE
                        {
                            IdCliente = ultimaFactura.ID_Cliente,
                            Nombre = ultimaFactura.NombreCompleto,
                            IdFactura = ultimaFactura.ID_Factura.HasValue ? ultimaFactura.ID_Factura.Value : 0,
                            FechaEmision = ultimaFactura.FechaEmision.HasValue ? ultimaFactura.FechaEmision.Value : default(DateTime),
                            Total = ultimaFactura.MontoTotal,
                            EstadoFactura = ultimaFactura.Estado_Cliente
                        };
                    }
                }

                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la última factura del cliente: " + ex.Message);
            }
        }
    }
}
