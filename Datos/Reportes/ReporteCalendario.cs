using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Reportes
{
    class ReporteCalendario
    {
        //Esta clase se utiliza en el javascript del FullCalendar de jQuery
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
