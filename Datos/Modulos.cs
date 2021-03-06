//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Modulos
    {
        public Modulos()
        {
            this.Tareas = new HashSet<Tareas>();
        }
    
        public int idModulo { get; set; }
        public int idProyecto { get; set; }
        public int idUsuarioCreador { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaFinalizacion { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public int Baja { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        public virtual ICollection<Tareas> Tareas { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}
