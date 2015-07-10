using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class DatosMail
    {
        public int idMail { get; set; }
        public int idProyecto { get; set; }
        public int idModulo { get; set; }
        public int idTarea { get; set; }
        public string asunto { get; set; }
        public string detalle { get; set; }
        public string enviado { get; set; }
        public string destinatarios { get; set; }
    }
}
