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
    
    public partial class Participantes
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public string PermisosAdministrador { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
