//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyTurismo_ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_Alojamiento
    {
        public int ID_Alojamiento { get; set; }
        public string Nom_Alo { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Ubicacion { get; set; }
        public int ID_Categoria { get; set; }
        public string Usu_Reg { get; set; }
        public Nullable<System.DateTime> Fec_Reg { get; set; }
        public string Usu_ult_Mod { get; set; }
        public Nullable<System.DateTime> Fec_ult_mod { get; set; }
        public string Estado { get; set; }
    
        public virtual Tb_Categoria Tb_Categoria { get; set; }
        public virtual Tb_Cliente Tb_Cliente { get; set; }
        public virtual Tb_Ubicacion Tb_Ubicacion { get; set; }
    }
}
