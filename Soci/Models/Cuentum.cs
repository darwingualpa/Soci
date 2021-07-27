using System;
using System.Collections.Generic;

#nullable disable


namespace Soci.Models
{
    public partial class Cuentum
    {
        public string Numero { get; set; }
        public string SaldoTotal { get; set; }
        public string CodigoSocio { get; set; }
        public int Estado { get; set; }

        public virtual Socio CodigoSocioNavigation { get; set; }
    }
}
