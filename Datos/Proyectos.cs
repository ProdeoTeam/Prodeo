//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Proyectos
    {
        public Proyectos()
        {
            this.Modulos = new HashSet<Modulos>();
            this.ParticipantesProyectos = new HashSet<ParticipantesProyectos>();
        }
    
        public int idProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public Nullable<System.DateTime> FechaFinalizacion { get; set; }
        public string AlertaPrevia { get; set; }
        public int Baja { get; set; }
    
        public virtual ICollection<Modulos> Modulos { get; set; }
        public virtual ICollection<ParticipantesProyectos> ParticipantesProyectos { get; set; }
    }
}
