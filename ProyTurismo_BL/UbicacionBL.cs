using ProyTurismo_ADO;
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
    }
}
