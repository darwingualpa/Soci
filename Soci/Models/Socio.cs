﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soci.Models
{
    public class Socio
    {
        public Socio()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}

