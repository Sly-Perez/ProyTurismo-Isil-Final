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
    
    public partial class Tb_Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Tour()
        {
            this.Tb_Reserva = new HashSet<Tb_Reserva>();
        }
    
        public int ID_Tour { get; set; }
        public string Est_Tour { get; set; }
        public System.DateTime Fec_Ini_Tour { get; set; }
        public System.DateTime Fec_Fin_Tour { get; set; }
        public int ID_Empleado { get; set; }
        public int ID_Transporte { get; set; }
        public int ID_Ubicacion { get; set; }
    
        public virtual Tb_Empleado Tb_Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Reserva> Tb_Reserva { get; set; }
        public virtual Tb_Transporte Tb_Transporte { get; set; }
        public virtual Tb_Ubicacion Tb_Ubicacion { get; set; }
    }
}