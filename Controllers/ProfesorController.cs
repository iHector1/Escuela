using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Model;
using Escuela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Escuela.Controllers {
    public class ProfesorController : Controller {
        public IActionResult lista_profesores () {
            EscuelaFULLContext db = new EscuelaFULLContext ();
            return View (db.Profesor.ToList ());
        }

        public IActionResult Crear_Profesor () {

            return View ();
        }
        [HttpPost]
        public IActionResult Crear_Profesor (Profesor profesor) {

            return View ();
        }
    }
}