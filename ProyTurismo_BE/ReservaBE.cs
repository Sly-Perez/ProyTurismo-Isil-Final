using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BE
{
    public class ReservaBE
    {
        public Int16 Id_Reserva { get; set; }
        public Int16 Id_Cliente { get; set; }
        public Int16 Id_Tour { get; set; }
        public Int16 Id_Ubicacion { get; set; }
        public String Departamento {  get; set; }
        public String Provincia {  get; set; }
        public String Distrito {  get; set; }
        public Single Total {  get; set; }
        public DateTime Fec_Res { get; set; }
        public String Usu_Reg { get; set; }
        public DateTime Fec_Reg { get; set; }
        public String Usu_Ult_Mod { get; set; }
        public DateTime Fec_Ult_Mod { get; set; }
        public String Estado { get; set; }
    }
}
