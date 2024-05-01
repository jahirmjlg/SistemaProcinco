using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaProcinco.API.Servicios;
using SistemaProcinco.BusinessLogic.Services;
using SistemaProcinco.Common.Models;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _accesoService.ListaUsuarios();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("UsuarioCrear")]
        public IActionResult Insert(UsuariosViewModel item)
        {
            var model = _mapper.Map<tbUsuarios>(item);
            var modelo = new tbUsuarios()
            {
                Usua_Usuario = item.Usua_Usuario,
                Usua_Contraseña = item.Usua_Contraseña,
                Usua_EsAdmin = item.Usua_EsAdmin,
                Empl_Id = item.Empl_Id,
                Role_Id = item.Role_Id,
                Usua_UsuarioCreacion = 1,
                Usua_FechaCreacion = DateTime.Now
            };
            var list = _accesoService.InsertarUsuarios(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("UsuarioEditar")]
        public IActionResult Edit(UsuariosViewModel item)
        {
            var model = _mapper.Map<tbUsuarios>(item);
            var modelo = new tbUsuarios()
            {
                Usua_Id = item.Usua_Id,
                Usua_Usuario = item.Usua_Usuario,
                Usua_EsAdmin = item.Usua_EsAdmin,
                Empl_Id = item.Empl_Id,
                Role_Id = item.Role_Id,
                Usua_UsuarioModificacion = 1,
                Usua_FechaModificacion = DateTime.Now
            };
            var list = _accesoService.EditarUsuarios(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }
    }
}
