﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class prodeoEntities : DbContext
    {
        public prodeoEntities()
            : base("name=prodeoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Participantes> Participantes { get; set; }
        public virtual DbSet<ParticipantesTareas> ParticipantesTareas { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ParticipantesProyectos> ParticipantesProyectos { get; set; }
        public virtual DbSet<Tareas> Tareas { get; set; }
    }
}
