using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class Profesor
    {
        public Profesor()
        {
            Permiso = new HashSet<Permiso>();
        }

        public int NominaProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public string ApellidoPaternoProfesor { get; set; }
        public string ApelidoMaternoProfesor { get; set; }
        public DateTime? FechaNacimientoProfesor { get; set; }
        public string CorreoProfesor { get; set; }
        public string ContraseñaProfesor { get; set; }
        public int? IdContrato { get; set; }
        public int? IdPlantel { get; set; }
        public short? HorasAsignadasProfesor { get; set; }
        public string CurpProfesor { get; set; }

        public virtual Contrato IdContratoNavigation { get; set; }
        public virtual Plantel IdPlantelNavigation { get; set; }
        public virtual ICollection<Permiso> Permiso { get; set; }
    }
}
