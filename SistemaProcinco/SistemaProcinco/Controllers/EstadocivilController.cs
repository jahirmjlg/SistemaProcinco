﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Controllers
{
    public class EstadocivilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
