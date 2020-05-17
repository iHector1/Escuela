using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Escuela.Models;
using Escuela.Model;
namespace Escuela.Controllers
{
    public class ProfesorController : Controller
    {
        public IActionResult lista_profesores()
        {
            EscuelaFULLContext db = new EscuelaFULLContext();
            return View(db.Profesor.ToList());
        }

    }
}
