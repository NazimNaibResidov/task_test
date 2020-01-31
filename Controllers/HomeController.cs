using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test_Task.WebUI.Core;
using Test_Task.WebUI.Data;

namespace Test_Task.WebUI.Controllers
{
    public class HomeController : Controller
    {
       
        
        public IActionResult Index()
        {
            return View();
        }
    }
}