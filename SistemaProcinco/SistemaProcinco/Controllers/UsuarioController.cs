using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaProcinco.API.Servicios;
using SistemaProcinco.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AccesoService _accesoService;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public UsuarioController(AccesoService accesoService, IMapper mapper, IMailService mailService)
        {
            _accesoService = accesoService;
            _mapper = mapper;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
