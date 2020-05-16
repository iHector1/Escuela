using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class Contrato
    {
        public Contrato()
        {
            Coordinador = new HashSet<Coordinador>();
            Profesor = new HashSet<Profesor>();
        }

        public int IdContrato { get; set; }
        public decimal? SueldoContrato { get; set; }
        public int? IdTipoTrabajador { get; set; }
        public int? IdTipoContrato { get; set; }

        public virtual TipoContrato IdTipoContratoNavigation { get; set; }
        public virtual ICollection<Coordinador> Coordinador { get; set; }
        public virtual ICollection<Profesor> Profesor { get; set; }
    }
}
