using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio4_EDD.Session
{
    public class clsCalculos
    {
        public static int CalularEdad(DateTime Fecha)
        {
            if (Fecha.Month < DateTime.Now.Month)
            {
                if (DateTime.Now.Day > Fecha.Day)
                {
                    return DateTime.Now.Year - Fecha.Year;
                }
                else
                {
                    return DateTime.Now.Year - Fecha.Year - 1;
                }
            }
            else if (Fecha.Month > DateTime.Now.Month)
            {
                return DateTime.Now.Year - Fecha.Year - 1;
            }
            else
            {
                if (DateTime.Now.Day <= Fecha.Day)
                {

                    return DateTime.Now.Year - Fecha.Year;
                }
                else
                {

                    return DateTime.Now.Year - Fecha.Year - 1;
                }
            }

        }
    }
}
