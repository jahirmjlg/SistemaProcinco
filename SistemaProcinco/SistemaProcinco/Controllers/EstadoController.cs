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

        [HttpDelete("EstadoEliminar")]
        public IActionResult Delete(string Est_Id)
        {
            var list = _generalService.EliminarEstados(Est_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("EstadoBuscar")]
        public IActionResult Details(string Esta_Id)
        {
            var list = _generalService.BuscarEstados(Esta_Id);
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
