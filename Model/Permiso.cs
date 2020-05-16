using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class Permiso
    {
        public int IdPermiso { get; set; }
        public string MotivoPermiso { get; set; }
        public DateTime? FechaSolicitudPermiso { get; set; }
        public DateTime? FechaInicioPermiso { get; set; }
        public DateTime? FechaTerminoPermiso { get; set; }
        public int? TipoPermiso { get; set; }
        public int? Nomina { get; set; }
        public int? Estado { get; set; }
        public TimeSpan? HoraInicioPermiso { get; set; }
        public TimeSpan? HoraTeminoPermiso { get; set; }

        public virtual EstadoPermiso EstadoNavigation { get; set; }
        public virtual Profesor NominaNavigation { get; set; }
        public virtual TipoPermiso TipoPermisoNavigation { get; set; }
    }
}
