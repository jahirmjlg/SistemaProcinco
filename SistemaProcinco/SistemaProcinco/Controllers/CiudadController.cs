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

        [HttpGet("ddl/{id}")]
        public IActionResult Lista(string id)
        {
            var listado = _generalService.GetCiudadesPorEstados(id);
            var drop = listado.Data as List<tbCiudades>;

            if(drop != null)
            {
                var ciud = drop.Select(x => new SelectListItem
                {
                    Text = x.Ciud_Descripcion,
                    Value = x.Ciud_Id

                }).ToList();

                ciud.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

                return Ok(ciud.ToList());
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

        [HttpDelete("CiudadEliminar/{id}")]
        public IActionResult Delete(string id)
        {
            var list = _generalService.EliminarCiudades(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

     

        [HttpGet("CiudadBuscar/{id}")]
        public IActionResult Details(string id)
        {
            var list = _generalService.BuscarCiudades(id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }
    }
}
