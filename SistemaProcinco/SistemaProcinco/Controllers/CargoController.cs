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
    public class CargoController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public CargoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }

        [HttpGet("CargoListado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaCargos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }


        [HttpGet("ddl")]
        public IActionResult Lista()
        {
            var listado = _procincoService.ListaCargos();
            var drop = listado.Data as List<tbCargos>;
            var carg = drop.Select(x => new SelectListItem
            {
                Text = x.Carg_Descripcion,
                Value = x.Carg_Id.ToString()

            }).ToList();

            carg.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(carg.ToList());
        }


        [HttpPost("CargoCrear")]
        public IActionResult Insert(CargosViewModel item)
        {
            var model = _mapper.Map<tbCargos>(item);
            var modelo = new tbCargos()
            {
                Carg_Descripcion = item.Carg_Descripcion,
                Carg_UsuarioCreacion = 1,
                Carg_FechaCreacion = DateTime.Now


            };
            var list = _procincoService.InsertarCargos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("CargoEditar")]
        public IActionResult Edit(CargosViewModel item)
        {
            var model = _mapper.Map<tbCargos>(item);
            var modelo = new tbCargos()
            {
                Carg_Id = item.Carg_Id,
                Carg_Descripcion = item.Carg_Descripcion,
                Carg_UsuarioModificacion = 1,
                Carg_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarCargos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("CargoEliminar/{Carg_Id}")]
        public IActionResult Delete(int Carg_Id)
        {
            var list = _procincoService.EliminarCargos(Carg_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("CargoBuscar/{Carg_Id}")]
        public IActionResult Details(int Carg_Id)
        {
            var list = _procincoService.BuscarCargos(Carg_Id);
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
