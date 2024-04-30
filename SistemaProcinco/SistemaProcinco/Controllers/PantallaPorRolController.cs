using AutoMapper;
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
    public class PantallaPorRolController : Controller
    {
        private readonly AccesoService _accesoService;
        private readonly IMapper _mapper;

        public PantallaPorRolController(AccesoService accesoService, IMapper mapper)
        {
            _accesoService = accesoService;
            _mapper = mapper;
        }


        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _accesoService.ListaPantallas();
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
