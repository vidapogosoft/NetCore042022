using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    public class Beta1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}