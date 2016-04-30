using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TareasPorModulos
    {
        public string modulo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizacion { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string estado { get; set; }
        public string condicionvencimiento { get; set; }
    }
}
