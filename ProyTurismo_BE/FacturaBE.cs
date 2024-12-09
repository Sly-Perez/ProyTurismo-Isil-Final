using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BE
{
    public class FacturaBE
    {
        public Int16 Id_Factura { get; set; }
        public Int16 Id_Reserva { get; set; }
        public DateTime Fec_Emi { get; set; }
        public Single Total { get; set; }
        public Int16 Met_Pag { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public String Auditoria { get; set; }




    }
}
