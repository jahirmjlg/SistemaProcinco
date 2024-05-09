using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaProcinco.BunisessLogic;
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
        public IActionResult Insert([FromBody] RoleWithScreens data)
        {
            var result = new ServicesResult();
            var rol = data.role_Descripcion;
            var pantallas = data.Screens;

            var modelo = new tbRoles()
            {
                Role_Descripcion = rol,
                Role_UsuarioCreacion = 1,
                Role_FechaCreacion = DateTime.Now
            };
            (var list, int Role_IdScope ) = _accesoService.InsertarRoles(modelo);


            foreach (var pantalla in pantallas)
            {
                var modelo2 = new tbPantallasPorRoles()
                {
                    Pant_Id = pantalla.pant_Id,
                    Role_Id = Role_IdScope,
                    PaPr_UsuarioCreacion = 1
                };

             result = _accesoService.InsertarPantallasPorRoles(modelo2);


            }


            if (result.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("RolEditar")]
        public IActionResult Edit([FromBody] RoleWithScreens data)
        {
            var result = new ServicesResult();
            var rol = data.role_Descripcion;
            var pantallas = data.Screens;

            var modelo = new tbRoles()
            {
                Role_Id = data.role_Id,
                Role_Descripcion = rol,
                Role_UsuarioCreacion = 1,
                Role_FechaCreacion = DateTime.Now
            };
            var list = _accesoService.EditarRoles(modelo);

            var limpiar = _accesoService.EliminarPantallasPorRoles(data.role_Id);


            foreach (var pantalla in pantallas)
            {
                var modelo2 = new tbPantallasPorRoles()
                {
                    Pant_Id = pantalla.pant_Id,
                    Role_Id = data.role_Id,
                    PaPr_UsuarioModificacion = 1
                };

                result = _accesoService.InsertarPantallasPorRoles(modelo2);

            }

            if (result.Success == true)
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

        [HttpGet("Buscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _accesoService.BuscarRoles(id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }


        [HttpGet("PantallasRoles/{id}")]
        public IActionResult ListadoFiltro(int id)
        {
            var listado = _accesoService.ListaPantallasRol(id);
            if (listado.Success == true)
            {
                return Ok(listado.Data);
            }
            else
            {
                return Problem();
            }
        }
    }
}
