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
    
    public partial class Tb_Transporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Transporte()
        {
            this.Tb_Tour = new HashSet<Tb_Tour>();
        }
    
        public int ID_Transporte { get; set; }
        public string Tip_Tra { get; set; }
        public Nullable<int> Mod_Tra { get; set; }
        public string Placa { get; set; }
        public string Est_Tra { get; set; }
        public int ID_Empleado { get; set; }
        public string Usu_Reg { get; set; }
        public Nullable<System.DateTime> Fec_Reg { get; set; }
        public string Usu_ult_Mod { get; set; }
        public Nullable<System.DateTime> Fec_ult_mod { get; set; }
        public string Estado { get; set; }
    
        public virtual Tb_Empleado Tb_Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Tour> Tb_Tour { get; set; }
    }
}