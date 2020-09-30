using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace neohsuporte.Controllers
{
    public class TutorialController : Controller
    {
        public IActionResult Medico()
        {
            return View();
        }

        public IActionResult Agendador()
        {
            return View();
        }

        public IActionResult Gestor()
        {
            return View();
        }

        public IActionResult Administrador()
        {
            return View();
        }
    }
}
