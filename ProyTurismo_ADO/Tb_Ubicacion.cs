
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ProyTurismo_ADO
{

using System;
    using System.Collections.Generic;
    
public partial class Tb_Ubicacion
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Tb_Ubicacion()
    {

        this.Tb_Alojamiento = new HashSet<Tb_Alojamiento>();

        this.Tb_Tour = new HashSet<Tb_Tour>();

    }


    public int ID_Ubicacion { get; set; }

    public string Departamento { get; set; }

    public string Provincia { get; set; }

    public string Distrito { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Tb_Alojamiento> Tb_Alojamiento { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Tb_Tour> Tb_Tour { get; set; }

}

}
