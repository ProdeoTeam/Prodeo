using System;
using System.Collections.Generic;
using Datos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProyectoLogica
    {
        public bool insertaProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.insertarProyecto(nombre,descrip,fechaCreacion,fechaVencimiento,alerta) != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
