using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class RolController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AccesoService _accesoService;
        public RolController(IMapper mapper, AccesoService accesoService)
        {
            _mapper = mapper;
            _accesoService = accesoService;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _accesoService.ListaRoles();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("RolCrear")]
        public IActionResult Insert(RolesViewModel item)
        {
            var model = _mapper.Map<tbRoles>(item);
            var modelo = new tbRoles()
            {
                Role_Descripcion = item.Role_Descripcion,
                Role_UsuarioCreacion = 1,
                Role_FechaCreacion = DateTime.Now
            };
            (var list, int Role_Id ) = _accesoService.InsertarRoles(modelo);
            list.Message = Role_Id.ToString();
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("RolEditar")]
        public IActionResult Edit(RolesViewModel item)
        {
            var model = _mapper.Map<tbRoles>(item);
            var modelo = new tbRoles()
            {
                Role_Id = item.Role_Id,
                Role_Descripcion = item.Role_Descripcion,
                Role_UsuarioModificacion = 1,
                Role_FechaModificacion = DateTime.Now


            };
            var list = _accesoService.EditarRoles(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("RolEliminar/{Role_id}")]
        public IActionResult Delete(int Role_id)
        {
            var list = _accesoService.EliminarRoles(Role_id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("ddl")]
        public IActionResult Lista()
        {
            var listado = _accesoService.ListaRoles();
            var drop = listado.Data as List<tbRoles>;
            var esta = drop.Select(x => new SelectListItem
            {
                Text = x.Role_Descripcion,
                Value = x.Role_Id.ToString()

            }).ToList();

            esta.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(esta.ToList());
        }
    }
}
