using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BE
{
    public class ClientesBE
    {

        public Int16 ID_Cliente { get; set; }
        public String Nom_Cli { get; set; }
        public String Ape_Cli { get; set; }
        public String Dni_Cli { get; set; }
        public String Num_Tel { get; set; }
        public String Email_Cli { get; set; }
        public DateTime Fec_Nac { get; set; }
        public String Sex_Cli { get; set; }
        public String Usu_Reg { get; set; }
        public DateTime Fec_Reg { get; set; }
        public String Usu_Ult_Mod { get; set; }
        public DateTime Fec_Ult_Mod { get; set; }
        public String Estado { get; set; }
    }
}
