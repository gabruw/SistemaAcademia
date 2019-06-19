using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SemAutorizacao()
        {
            return View();
        }

        public IActionResult SemPermissao()
        {
            return View();
        }
    }
}