using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericsList.OtherStructures;
using Laboratorio4_EDD.DTO;
namespace Laboratorio4_EDD.DataBase
{
    public static class DataBase
    {
        public static int ComparePriority(int value1, int value2)
        {
            if (value1 > value2)
            {
                return 1;
            }
            else if (value1 < value2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static int GetPriority(PacientesDTO pacientes)
        {
            return pacientes.Prioridad;
        }
        public static HeapUsingTree<int, PacientesDTO> Cola = new HeapUsingTree<int, PacientesDTO>(GetPriority,ComparePriority);

        public static List<EspecializacionDTO> Especializacion = new List<EspecializacionDTO>
        {
        new EspecializacionDTO{ Especializacion="Traumatología (Interna)",Puntos=3},
        new EspecializacionDTO{ Especializacion="Traumatología (expuesta)",Puntos=8},
        new EspecializacionDTO{ Especializacion="Cardiología",Puntos=10},
        new EspecializacionDTO{ Especializacion="Neumología",Puntos=8}
        };
        public static List<IngresoDTO> Ingreso = new List<IngresoDTO>
        {
           new IngresoDTO{ Ingreso="Ambulancia",Puntos=5},
           new IngresoDTO{ Ingreso="Asistido",Puntos=3},
        };
    }
}
