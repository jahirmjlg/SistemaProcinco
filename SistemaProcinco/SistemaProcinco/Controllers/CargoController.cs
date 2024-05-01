﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaProcinco.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public CargoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaCargos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }
    }
}
