using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class TipoPermiso
    {
        public TipoPermiso()
        {
            Permiso = new HashSet<Permiso>();
        }

        public int IdTipoPermiso { get; set; }
        public string NombreTipooPermiso { get; set; }

        public virtual ICollection<Permiso> Permiso { get; set; }
    }
}
