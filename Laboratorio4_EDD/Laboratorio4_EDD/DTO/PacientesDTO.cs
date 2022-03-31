using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio4_EDD.DTO
{
    public class PacientesDTO
    {
        public string Nombres { get; set; }

        public string Apellido { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public int Edad { get; set; }
        public string Sexo { get; set; }

        public string Epecializacion { get; set; }

        public string Metodo_Ingreso { get; set; }
        public int Prioridad { get; set; }
    }
}
