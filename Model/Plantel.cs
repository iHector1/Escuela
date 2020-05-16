using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class Plantel
    {
        public Plantel()
        {
            Profesor = new HashSet<Profesor>();
        }

        public int IdPlantel { get; set; }
        public string NombrePlantel { get; set; }
        public string DireccionPlantel { get; set; }

        public virtual ICollection<Profesor> Profesor { get; set; }
    }
}
