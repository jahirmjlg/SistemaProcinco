using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int Role_Id)
        {
            var listado = _accesoService.ListaPantallasPorRoles(Role_Id);
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("PantallaPorRolCrear")]
        public IActionResult Insert(PantallasPorRolesViewModel item)
        {
            var model = _mapper.Map<tbPantallasPorRoles>(item);
            var modelo = new tbPantallasPorRoles()
            {
                Pant_Id = item.Pant_Id,
                Role_Id = item.Role_Id,
                PaPr_UsuarioCreacion = 1,
                PaPr_FechaCreacion = DateTime.Now


            };
            var list = _accesoService.InsertarPantallasPorRoles(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("PantallaPorRolEditar")]
        public IActionResult Edit(PantallasPorRolesViewModel item)
        {
            var model = _mapper.Map<tbPantallasPorRoles>(item);
            var modelo = new tbPantallasPorRoles()
            {
                PaPr_Id = item.PaPr_Id,
                Pant_Id = item.Pant_Id,
                Role_Id = item.Role_Id,
                PaPr_UsuarioModificacion = 1,
                PaPr_FechaModificacion = DateTime.Now
            };
            var list = _accesoService.EditarPantallasPorRoles(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("PantallaPorRolEliminar/{PaPr_id}")]
        public IActionResult Delete(int PaPr_id)
        {
            var list = _accesoService.EliminarPantallasPorRoles(PaPr_id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("PantallaPorRolBuscar/{PaPr_Id}")]
        public IActionResult Details(int PaPr_Id)
        {
            var list = _accesoService.BuscarPantallasPorRoles(PaPr_Id);
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
