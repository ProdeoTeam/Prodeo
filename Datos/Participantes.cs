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
    
    public partial class Participantes
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public string PermisosAdministrador { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
