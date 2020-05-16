using System;
using System.Collections.Generic;

namespace Escuela.Model
{
    public partial class Coordinador
    {
        public int NominaCoordinador { get; set; }
        public string NombreCoordinador { get; set; }
        public string ApellidoPaternoCoordinador { get; set; }
        public string ApelidoMaternoCoordinador { get; set; }
        public DateTime? FechaNacimientoCoordinador { get; set; }
        public string CorreoCoordinador { get; set; }
        public string ContraseñaCoordinador { get; set; }
        public int? IdContrato { get; set; }
        public int? IdPlantel { get; set; }
        public short? HorasAsignadasCoordinador { get; set; }
        public string CurpCoordinador { get; set; }

        public virtual Contrato IdContratoNavigation { get; set; }
    }
}
