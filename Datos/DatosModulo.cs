using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosModulo
    {
        public int IdModulo { get; set; }
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DataTable tablaTareas { get; set; }

    }
}
