using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BE
{
    public class UbicacionBE
    {
        public Int16 Id_Ubicacion { get; set; }
        public String Departamento { get; set; }
        public String Provincia { get; set; }
        public String Distrito { get; set; }
    }

    public class UbicacionFacturacionBE
    {
        public String Departamento { get; set; }
        public Single MontoTotalGenerado {  get; set; }
        public int CantidadReservas {  get; set; }
    }

}
