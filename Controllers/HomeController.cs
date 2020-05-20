using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Escuela.Models;
using Escuela.Model;
using System.Web;

namespace Escuela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
           _logger = logger;
        }

        public IActionResult Index( string message="")
        {
            ViewBag.Messge = message;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult login(string message="") { 
                        ViewBag.Messge = message;

            return View();
        }
        [HttpPost]
        public IActionResult login(string Nomina ,string contraseña)
        {
            if (!string.IsNullOrEmpty(Nomina) && !string.IsNullOrEmpty(contraseña)) { 
            int nomina = Int32.Parse(Nomina);
            EscuelaFULLContext db = new EscuelaFULLContext();
            var user =db.Profesor.FirstOrDefault(p => p.NominaProfesor == nomina && p.ContraseñaProfesor == contraseña);
                if (user!=null) {
                    return RedirectToAction("lista_profesores", "Profesor");
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
