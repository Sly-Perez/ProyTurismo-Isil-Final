﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProyectoTurismoEntities : DbContext
    {
        public ProyectoTurismoEntities()
            : base("name=ProyectoTurismoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tb_Alojamiento> Tb_Alojamiento { get; set; }
        public virtual DbSet<Tb_Categoria> Tb_Categoria { get; set; }
        public virtual DbSet<Tb_Cliente> Tb_Cliente { get; set; }
        public virtual DbSet<Tb_Empleado> Tb_Empleado { get; set; }
        public virtual DbSet<Tb_Factura> Tb_Factura { get; set; }
        public virtual DbSet<Tb_Reserva> Tb_Reserva { get; set; }
        public virtual DbSet<Tb_Tour> Tb_Tour { get; set; }
        public virtual DbSet<Tb_Transporte> Tb_Transporte { get; set; }
        public virtual DbSet<Tb_Ubicacion> Tb_Ubicacion { get; set; }
        public virtual DbSet<Tb_Usuario> Tb_Usuario { get; set; }
    }
}