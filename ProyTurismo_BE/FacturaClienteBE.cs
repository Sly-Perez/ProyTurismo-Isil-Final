using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BE
{
   
        public class FacturaClienteBE
        {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal? Total { get; set; } 
        public string EstadoFactura { get; set; }
    }
    }


