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
    public class CiudadController : Controller
    {
        private readonly IMapper _mapper;
        private readonly GeneralService _generalService;
        public CiudadController(IMapper mapper, GeneralService generalService)
        {
            _mapper = mapper;
            _generalService = generalService;
        }

        [HttpGet("CiudadListado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListaCiudades();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }


        [HttpPost("CiudadCrear")]
        public IActionResult Insert(CiudadesViewModel item)
        {
            var model = _mapper.Map<tbCiudades>(item);
            var modelo = new tbCiudades()
            {
                Ciud_Id = item.Ciud_Id,
                Ciud_Descripcion = item.Ciud_Descripcion,
                Esta_Id = item.Esta_Id,
                Ciud_UsuarioCreacion = 1,
                Ciud_FechaCreacion = DateTime.Now


            };
            var list = _generalService.InsertarCiudades(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("CiudadEditar")]
        public IActionResult Edit(CiudadesViewModel item)
        {
            var model = _mapper.Map<tbCiudades>(item);
            var modelo = new tbCiudades()
            {
                Ciud_Id = item.Ciud_Id,
                Ciud_Descripcion = item.Ciud_Descripcion,
                Esta_Id = item.Esta_Id,
                Ciud_UsuarioModificacion = 1,
                Ciud_FechaModificacion = DateTime.Now


            };
            var list = _generalService.EditarCiudades(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("EstadoEliminar/{Ciud_Id}")]
        public IActionResult Delete(string Ciud_Id)
        {
            var list = _generalService.EliminarCiudades(Ciud_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("CiudadBuscar/{Ciud_Id}")]
        public IActionResult Details(string Ciud_Id)
        {
            var list = _generalService.BuscarCiudades(Ciud_Id);
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
