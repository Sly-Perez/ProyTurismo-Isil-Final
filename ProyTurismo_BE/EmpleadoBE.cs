using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyTurismo_BE
{
    public class EmpleadoBE
    {
        public int ID_Empleado { get; set; }
        public string Nom_Emp { get; set; }
        public string Ape_Emp { get; set; }
        public string Dni_Emp { get; set; }
        public string Tel_Emp { get; set; }
        public string Email_Emp { get; set; }
        public string Rol_Emp { get; set; }
        public int? Supervisor_ID { get; set; } 
        public DateTime? Fec_Reg { get; set; } 

        public DateTime? Fec_ult_mod { get; set; } 

        public string Estado { get; set; }
    }
}
