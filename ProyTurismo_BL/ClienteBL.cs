using ProyTurismo_ADO;
using ProyTurismo_BE;
using System;
using System.Collections.Generic;

namespace ProyTurismo_BL
{
    public class ClienteBL
    {
        ClienteADO objClienteADO = new ClienteADO();

        // Métodos de facturación existentes
        public List<FacturaClienteBE> ListarFacturacionClienteEntreFechasYEstado(int idCliente, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            return objClienteADO.ListarFacturacionClienteEntreFechasYEstado(idCliente, fechaInicio, fechaFin, estado);
        }

        public List<FacturaClienteBE> ListarFacturacionClientePorEstado(int idCliente, string estado)
        {
            return objClienteADO.ListarFacturacionClientePorEstado(idCliente, estado);
        }

        public List<FacturaClienteBE> ListarFacturacionClienteEntreFechas(int idCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            return objClienteADO.ListarFacturacionClienteEntreFechas(idCliente, fechaInicio, fechaFin);
        }

        public FacturaClienteBE ObtenerUltimaFacturaCliente(int idCliente)
        {
            return objClienteADO.ObtenerUltimaFacturaCliente(idCliente);
        }

        // Nuevo método para listar reservas entre fechas
        public List<ClienteBE> ListarReservasEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return objClienteADO.ListarReservasEntreFechas(fechaInicio, fechaFin);
        }


    }
}
