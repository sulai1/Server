﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDemo.Controler
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Introduction()
        {
            return View();
        }

        public IActionResult FirstPage()
        {
            return View();
        }

        public IActionResult DatabaseConnection()
        {
            return View();
        }

        public IActionResult Identity()
        {
            return View();
        }

    }
}