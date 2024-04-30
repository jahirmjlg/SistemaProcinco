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
    public class RolController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AccesoService _accesoService;
        public RolController(IMapper mapper, AccesoService accesoService)
        {
            _mapper = mapper;
            _accesoService = accesoService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
