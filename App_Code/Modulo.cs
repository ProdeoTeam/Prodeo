using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace Prodeo.Entidad
{
    public class Modulo
    {
        public int IdModulo { get; set; }
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DataTable tablaTareas { get; set; }
    }
}