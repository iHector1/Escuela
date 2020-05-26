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
    public class PermisosController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PermisosController(ILogger<HomeController> logger)
        {
           _logger = logger;
        }
    }
}
