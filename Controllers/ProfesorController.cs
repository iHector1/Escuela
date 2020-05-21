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
        public IActionResult Crear_Profesor () { //vista para crear profesores

            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear_Profesor (Profesor profesor) {

            if (!ModelState.IsValid) return View ();
            try {
                using (var db = new EscuelaFULLContext ()) { // se hace la conexion a la base de datos 
                    db.Profesor.Add (profesor); //crea al profesor
                    db.SaveChanges (); //salva los cambios
                    return RedirectToAction ("lista_profesores"); //reedireciona a la lista de profesores
                }
            } catch (System.Exception ex) {
                ModelState.AddModelError ("No se puede Insertar al alumno", ex.Message);
                return View ();
            }

        }

        [HttpGet]
        public IActionResult Editar_profesor (int id) {
            int nomina = id;
            try {
                using (var db = new EscuelaFULLContext ()) {
                    Profesor profesor = db.Profesor.Find (nomina);
                    return View (profesor);
                }
            } catch (System.Exception ex) {
                ModelState.AddModelError ("No se puede Editar al alumno", ex.Message);
                return View ();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar_profesor (Profesor profesor) {
            try {
                using (var db = new EscuelaFULLContext ()) {
                    Profesor pro = db.Profesor.Find (profesor.NominaProfesor);
                    pro.ApellidoPaternoProfesor = profesor.ApellidoPaternoProfesor;
                    pro.FechaNacimientoProfesor = profesor.FechaNacimientoProfesor;
                    pro.CorreoProfesor = profesor.CorreoProfesor;
                    pro.ContraseñaProfesor = profesor.ContraseñaProfesor;
                    pro.IdContrato = profesor.IdContrato;
                    pro.IdPlantel = profesor.IdPlantel;
                    pro.HorasAsignadasProfesor = profesor.HorasAsignadasProfesor;
                    pro.CurpProfesor = profesor.CurpProfesor;
                    db.SaveChanges ();
                    return RedirectToAction ("lista_profesores");
                }
            } catch (System.Exception ex) {
                ModelState.AddModelError ("No se puede Editar al alumno", ex.Message);
                return View ();
            }
        }
        public IActionResult Eliminar_profesor (int id) {
            using (var db = new EscuelaFULLContext ()) {
                Profesor profesor = db.Profesor.Find (id);
                db.Profesor.Remove (profesor);
                db.SaveChanges ();
                return RedirectToAction ("lista_profesores");
            }
        }
        public IActionResult Detalles_profesor (int id) {
            using (var db = new EscuelaFULLContext ()) {
                Profesor profesor = db.Profesor.Find (id);
                return View (profesor);
            }

        }
    }
}