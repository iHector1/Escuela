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
        [HttpGet]
        public IActionResult Crear_Profesor () {//vista para crear profesores
            
            return View ();
        }
        [HttpPost]
        public IActionResult Crear_Profesor (Profesor profesor) {
            try
            {
                using (var db = new EscuelaFULLContext()) {// se hace la conexion a la base de datos 
                    db.Profesor.Add(profesor);//crea al profesor
                    db.SaveChanges();//salva los cambios
                    return RedirectToAction("lista_profesores");//reedireciona a la lista de profesores
                }
            }
            catch (System.Exception)
            {
                return View ();
            }
            
        }
    }
}