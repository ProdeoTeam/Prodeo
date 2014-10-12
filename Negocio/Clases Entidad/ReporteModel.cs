using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases_Entidad
{
    class ReporteModel
    {
        public string Nombre { get; set; }
        public int TareasPendientesNoVencidas { get; set; }
        public int TareasPendientesVencidas { get; set; }
        public int TareasFinalizadas { get; set; }
    }
}
