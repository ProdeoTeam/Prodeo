using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace Datos
{
    namespace Reportes
    {
        public class DatosReportes
        {
            public ArrayList Categorias { get; set; }
            public ArrayList Series { get; set; }
            public DatosReportes()
            {
                this.Categorias = new ArrayList();
                this.Series = new ArrayList();
            }
        }

    }

}
