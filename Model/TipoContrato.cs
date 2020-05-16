using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class TipoContrato
    {
        public TipoContrato()
        {
            Contrato = new HashSet<Contrato>();
        }

        public int IdTipoContrato { get; set; }
        public string NombreTipoContrato { get; set; }

        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
