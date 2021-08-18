using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetWebApp.Controllers
{
    public class LetController : Controller
    {
        public IActionResult Index()
        {

            return View("Letovi",null);
        }
    }
}
