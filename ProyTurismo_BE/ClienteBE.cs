using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BE
{
    public class ClienteBE
    {

        public string NombreCliente { get; set; }
        public string DNICliente { get; set; }
        public int IDCliente { get; set; }
        public int IDReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public string EstadoReserva { get; set; }
        public string NombreAlojamiento { get; set; }
        public string Categoria { get; set; }
        public decimal TarifaPorNoche { get; set; }
        public int Noches { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Tar_Por_Noc { get; set; }
    }
}
