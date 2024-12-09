using ProyTurismo_ADO;
using ProyTurismo_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BL
{
    public class ReservaBL
    {
        ReservaADO objReservaADO = new ReservaADO();

        public List<ReservaBE> ListarReservasDepartamentoFechas(String strDepartamento, DateTime fechaIni, DateTime fechaFin)
        {
            return objReservaADO.ListarReservasDepartamentoFechas(strDepartamento, fechaIni, fechaFin);
        }

        public List<ReservaBE> ListarReservasFechas(DateTime fechaIni, DateTime fechaFin)
        {
            return objReservaADO.ListarReservasFechas(fechaIni, fechaFin);
        }
        public Single CalcularTotalDepartamentoFechas(String strDepartamento, DateTime fechaIni, DateTime fechaFin)
        {
            return objReservaADO.CalcularTotalDepartamentoFechas(strDepartamento, fechaIni, fechaFin);
        }
    }
}
