using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosTarea
    {
        public int IdTarea { get; set; }
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Comentario { get; set; }
        public string Prioridad { get; set; }
        public string Avisos { get; set; }
        public string Asignada { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string Estado { get; set; }
    }
}
