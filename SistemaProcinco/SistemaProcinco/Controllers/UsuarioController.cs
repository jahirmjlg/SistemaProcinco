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
                Usua_EsAdmin = false,
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

        [HttpDelete("UsuarioEliminar/{usua_Id}")]
        public IActionResult Delete(int Usua_Id)
        {
            var list = _accesoService.EliminarUsuarios(Usua_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }


        [HttpGet("UsuarioLogin/{usuario},{contra}")]
        public IActionResult Login(string usuario, string contra)
        {
            var list = _accesoService.Login(usuario, contra);
            if (!list.Success)
            {
                return Problem();
            }
            else
            {
                return Ok(list);

            }
        }


        [HttpGet("EnviarCorreo/{correo_usuario}")]
        public IActionResult EnviarCorreo(string correo_usuario)
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000);
            var estado = _accesoService.EnviarCodigo(correo_usuario);
            var lista = estado.Data;
            if (lista.Count > 0)
            {
                var datos = estado.Data as List<tbUsuarios>;
                var first = datos.FirstOrDefault();
                _accesoService.Implementarcodigo(randomNumber.ToString(), first.Usua_Id);
                MailData mailData = new MailData();
                mailData.EmailToId = first.correo;
                mailData.EmailToName = "Usuario";
                mailData.EmailSubject = "Su codigo para restablecer contraseña es el siguiente";
                mailData.EmailBody = "" + randomNumber.ToString();
                _mailService.SendMail(mailData);
                return Ok(estado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("Buscar/{usua_Id}")]

        public IActionResult Details(int usua_Id)
        {
            var list = _accesoService.BuscarUsuarios(usua_Id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("ValidarCodigo/{usua_verificarCorreo}")]
        public IActionResult restablecer(string usua_verificarCorreo)
        {
            
            var lista = _accesoService.ValidarCodigo(usua_verificarCorreo);
            
            if (lista.Success == true)
            {
                return Ok(lista);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("RestablacerContrasena")]
        public IActionResult restablecer(UsuariosViewModel item)
        {
          
            var modelo = new tbUsuarios()
            {
                Usua_Id = item.Usua_Id,
                Usua_Contraseña = item.Usua_Contraseña,
                Usua_UsuarioModificacion = 1,
                Usua_FechaModificacion = DateTime.Now,
            };
            var list = _accesoService.RestablecerContrasenia(modelo);
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
