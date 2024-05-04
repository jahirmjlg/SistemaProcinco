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
    public class EstadoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public EstadoController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListaEstados();
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
            var listado = _generalService.ListaEstados();
            var drop = listado.Data as List<tbEstados>;
            var esta = drop.Select(x => new SelectListItem
            {
                Text = x.Esta_Descripcion,
                Value = x.Esta_Id

            }).ToList();

            esta.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(esta.ToList());
        }


        [HttpPost("EstadoCrear")]
        public IActionResult Insert(EstadosViewModel item)
        {
            var model = _mapper.Map<tbEstados>(item);
            var modelo = new tbEstados()
            {
                Esta_Id = item.Esta_Id,
                Esta_Descripcion = item.Esta_Descripcion,
                Esta_UsuarioCreacion = 1,
                Esta_FechaCreacion = DateTime.Now


            };
            var list = _generalService.InsertarEstados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("EstadoEditar")]
        public IActionResult Edit(EstadosViewModel item)
        {
            var model = _mapper.Map<tbEstados>(item);
            var modelo = new tbEstados()
            {
                Esta_Id = item.Esta_Id,
                Esta_Descripcion = item.Esta_Descripcion,
                Esta_UsuarioModificacion = 1,
                Esta_FechaModificacion = DateTime.Now


            };
            var list = _generalService.EditarEstados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("EstadoEliminar/{id}")]
        public IActionResult Delete(string id)
        {
            var list = _generalService.EliminarEstados(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("EstadoBuscar/{id}")]
        public IActionResult Details(string id)
        {
            var list = _generalService.BuscarEstados(id);
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
