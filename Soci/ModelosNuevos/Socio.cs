using System;
using System.Collections.Generic;

#nullable disable

namespace Soci.ModelosNuevos
{
    public partial class Socio
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
