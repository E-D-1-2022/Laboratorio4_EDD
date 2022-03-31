using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio4_EDD.DataBase;
using Laboratorio4_EDD.DTO;
using Laboratorio4_EDD.Session;
namespace Laboratorio4_EDD.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public int PuntosEdad(int Edad) {
            if (Edad >= 70)
            {
                return 10;
            }
            else if (Edad >= 50 && Edad <= 69)
            {
                return 8;
            }
            else if (Edad >= 18 && Edad <= 49)
            {
                return 3;
            }
            else if (Edad >= 6 && Edad <= 17)
            {
                return 5;
            }
            else if (Edad >= 0 && Edad <= 5)
            {
                return 8;
            }
            else {
                return 0;
            }
        }
        public int PuntosSexo(string Sexo) {
            if (Sexo == "Masculino")
            {
                return 3;
            }
            else {
                return 5;
            }
        }

        public int PuntosEspecializacion(string Especializacion) {
            return DataBase.DataBase.Especializacion.Find(x => x.Especializacion == Especializacion).Puntos;
        }
        public int PuntosIngreso(string Ingreso)
        {
            return DataBase.DataBase.Ingreso.Find(x => x.Ingreso ==Ingreso ).Puntos;
        }

        [HttpPost]
        public IActionResult InsertarPaciente() {
            PacientesDTO pacientesDTO = new PacientesDTO();
            pacientesDTO.Nombres = Request.Form["txtNombre"].ToString();
            pacientesDTO.Apellido = Request.Form["txtApellido"].ToString();
            pacientesDTO.Fecha_Nacimiento = DateTime.Parse(Request.Form["DtpFechaNac"].ToString());
            pacientesDTO.Edad = clsCalculos.CalularEdad(pacientesDTO.Fecha_Nacimiento);
            pacientesDTO.Sexo = Request.Form["cbsexo"].ToString();
            pacientesDTO.Epecializacion = Request.Form["cbEspecializacion"].ToString();
            pacientesDTO.Metodo_Ingreso = Request.Form["cbIngreso"].ToString();
            pacientesDTO.Prioridad = PuntosEdad(pacientesDTO.Edad) + PuntosSexo(pacientesDTO.Sexo) + PuntosEspecializacion(pacientesDTO.Epecializacion) + PuntosIngreso(pacientesDTO.Metodo_Ingreso);
            DataBase.DataBase.Cola.Insert(pacientesDTO);
            return View();
        }
        public void Ordernar(ref List<PacientesDTO> pacientesDTOs) {
            for (int x = 0; x < pacientesDTOs.Count; x++) {
                for (int y = x; y < pacientesDTOs.Count; y++) {
                    if (pacientesDTOs[x].Prioridad < pacientesDTOs[y].Prioridad) {
                        PacientesDTO temp = pacientesDTOs[x];
                        pacientesDTOs[x] = pacientesDTOs[y];
                        pacientesDTOs[y] = temp;
                    }
                }
            }
        }
        public IActionResult ListarPacientes() {
            List<PacientesDTO> pacientesDTOs = new List<PacientesDTO>();
            foreach (var item in DataBase.DataBase.Cola.nodesStack) {
              pacientesDTOs.Add(item.value);
            }
            Ordernar(ref pacientesDTOs);
            ViewData["ListaPacientes"] = pacientesDTOs;
            return View();
        }
        public IActionResult Eliminar() {
            DataBase.DataBase.Cola.Remove();
            return View();
        }
    }
}
