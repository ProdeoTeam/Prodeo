using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Datos
{
    namespace Reportes
    {
        public class Series
        {
            public string Nombre { get; set; }
            public ArrayList Datos { get; set; }
            public string Stack { get; set; }
            public Series()
            {
                Datos = new ArrayList();
            }
        }
    }

}
