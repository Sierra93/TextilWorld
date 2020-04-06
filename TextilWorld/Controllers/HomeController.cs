using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextilWorld.Models;

namespace TextilWorld.Controllers {
    /// <summary>
    /// Контроллер описывает все роуты приложения.
    /// </summary>
    public class HomeController : Controller {        
        public IActionResult Index() {
            return View();
        }
    }
}
