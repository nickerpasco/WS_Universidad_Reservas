﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_Universidad.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_aaf83c_universidadtestEntities : DbContext
    {
        public db_aaf83c_universidadtestEntities()
            : base("name=db_aaf83c_universidadtestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alquileres> Alquileres { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Canchas> Canchas { get; set; }
        public virtual DbSet<HorariosCancha> HorariosCancha { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<ReservaCancha> ReservaCancha { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}