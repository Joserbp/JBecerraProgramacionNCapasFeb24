﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        //public ML.Usuario Usuario { get; set; }
        public ML.Estado Estado { get; set; }
    }
}
