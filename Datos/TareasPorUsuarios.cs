﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TareasPorUsuarios
    {
        public string usuario { get; set; }
        public DateTime fechaFinalizacion { get; set; }
        public DateTime fechaVemcimiento { get; set; }
        public string estado { get; set; }
        public string condicionvencimiento { get; set; }
    }
}