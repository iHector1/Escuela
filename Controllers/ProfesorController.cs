using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Escuela.Model;
using Escuela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Escuela.library;
namespace Escuela.Controllers {
    public class ProfesorController : Controller {

        public int nomina;
        public IActionResult login(string message="") { 
                        ViewBag.Messge = message;

            return View();
        }
        [HttpPost]
        public IActionResult login(string Nomina ,string contraseña)
        {
            if (!string.IsNullOrEmpty(Nomina) && !string.IsNullOrEmpty(contraseña)) { 
             nomina = Int32.Parse(Nomina);
                contraseña = Seguridad.Encriptar(contraseña);
                EscuelaFULLContext db = new EscuelaFULLContext();
            var user =db.Profesor.FirstOrDefault(p => p.NominaProfesor == nomina && p.ContraseñaProfesor == contraseña);
                if (user!=null) {  
                    return RedirectToAction ("lista_profesores");
                }
                else { 
                    //hay error con los datos del usuario 
                    return login("No encotramos los datos");
                }
            }
            else {
                return login("llena los campos para iniciar sesion");
            }
        }
        public IActionResult lista_profesores () {//se crea la lista de profesores
            EscuelaFULLContext db = new EscuelaFULLContext ();
            return View (db.Profesor.ToList ());
        }

        [HttpGet]
        public IActionResult Crear_Profesor () { //vista para crear profesores

            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear_Profesor (Profesor profesor) {//se crea al profesor 
            if (!ModelState.IsValid) return View ();
            try {
                using (var db = new EscuelaFULLContext ()) { // se hace la conexion a la base de datos 
                    profesor.ContraseñaProfesor = Seguridad.Encriptar(profesor.ContraseñaProfesor);
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
        public IActionResult Editar_profesor (int id) {//Se busca al profesor y muestra sus resultados
            int nomina = id;
            try {
                using (var db = new EscuelaFULLContext ()) {
                    Profesor profesor = db.Profesor.Where(a => a.NominaProfesor == nomina).FirstOrDefault();
                    profesor.ContraseñaProfesor = Seguridad.DesEncriptar(profesor.ContraseñaProfesor);
                    return View (profesor);
                }
            } catch (System.Exception ex) {
                ModelState.AddModelError ("No se puede Editar al alumno", ex.Message);
                return View ();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar_profesor (Profesor profesor) {//Actualizamos al profesor 
            if (!ModelState.IsValid) return View ();
            try {
                using (var db = new EscuelaFULLContext ()) {//recibimos todos os cambios
                    Profesor pro = db.Profesor.Find (profesor.NominaProfesor);
                    pro.NombreProfesor = profesor.NombreProfesor;
                    pro.ApellidoPaternoProfesor = profesor.ApellidoPaternoProfesor;
                    pro.ApelidoMaternoProfesor = profesor.ApelidoMaternoProfesor;
                    pro.FechaNacimientoProfesor = profesor.FechaNacimientoProfesor;
                    pro.CorreoProfesor = profesor.CorreoProfesor;
                    pro.ContraseñaProfesor = Seguridad.Encriptar(profesor.ContraseñaProfesor);
                    pro.IdContrato = profesor.IdContrato;
                    pro.IdPlantel = profesor.IdPlantel;
                    pro.HorasAsignadasProfesor = profesor.HorasAsignadasProfesor;
                    pro.CurpProfesor = profesor.CurpProfesor;
                    db.Update(pro);
                    db.SaveChanges ();
                    return RedirectToAction ("lista_profesores");
                }
            } catch (System.Exception ex) {
                ModelState.AddModelError ("No se puede Editar al alumno", ex.Message);
                return View ();
            }
        }
        public IActionResult Eliminar_profesor (int id) {//Se elimnina al profesor 
            using (var db = new EscuelaFULLContext ()) {
                Profesor profesor = db.Profesor.Find (id);
                db.Profesor.Remove (profesor);
                db.SaveChanges ();
                return RedirectToAction ("lista_profesores");
            }
        }
        public IActionResult Detalles_profesor (int id) {//Se muestra los detalles del profesor 
            using (var db = new EscuelaFULLContext ()) {
                Profesor profesor = db.Profesor.Find (id);
                profesor.ContraseñaProfesor = Seguridad.Encriptar(profesor.ContraseñaProfesor);
                return View (profesor);
            }

        }
        [HttpGet]
        public IActionResult lista_permisos () {//Se busca al profesor y muestra sus resultados
            EscuelaFULLContext db = new EscuelaFULLContext();
            List<Permiso> permisos = db.Permiso.Where(a=>a.Nomina==nomina).ToList();
            return View (permisos);
        }
    }
}