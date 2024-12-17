using ProyTurismo_ADO;
using ProyTurismo_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BL
{
    public class UbicacionBL
    {
        UbicacionADO objUbicacionADO = new UbicacionADO();

        public List<String> ListarDepartamentosUbicaciones()
        {
            return objUbicacionADO.ListarDepartamentosUbicaciones();
        }

        public List<UbicacionFacturacionBE> ListarFacturacionUbicacion()
        {
            return objUbicacionADO.ListarFacturacionUbicacion();
        }
    }
}
