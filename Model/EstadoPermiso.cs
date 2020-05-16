using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class EstadoPermiso
    {
        public EstadoPermiso()
        {
            Permiso = new HashSet<Permiso>();
        }

        public int IdEstadoPermiso { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Permiso> Permiso { get; set; }
    }
}
