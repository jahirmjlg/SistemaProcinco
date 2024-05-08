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
    public class ContenidoPorCursoController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public ContenidoPorCursoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaContenidoPorCursos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("ContenidoPorCursoCrear")]
        public IActionResult Insert(ContenidoPorCursoViewModel item)
        {
            var model = _mapper.Map<tbContenidoPorCurso>(item);
            var modelo = new tbContenidoPorCurso()
            {
                Cont_Id = item.Cont_Id,
                Curso_Id = item.Curso_Id,
                ConPc_UsuarioCreacion = 1,
                ConPc_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarContenidosPorCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("ContenidoPorCursoEditar")]
        public IActionResult Edit(ContenidoPorCursoViewModel item)
        {
            var model = _mapper.Map<tbContenidoPorCurso>(item);
            var modelo = new tbContenidoPorCurso()
            {
                ConPc_Id = item.ConPc_Id,
                Cont_Id = item.Cont_Id,
                Curso_Id = item.Curso_Id,
                ConPc_UsuarioModificacion = 1,
                ConPc_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarContenidosPorCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("ContenidoPorCursoEliminar/{ConPc_Id}")]
        public IActionResult Delete(int ConPc_Id)
        {
            var list = _procincoService.EliminarContenidosPorCursos(ConPc_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("ContenidoPorCursoBuscar/{ConPc_Id}")]
        public IActionResult BuscarCurso(int ConPc_Id)
        {
            var list = _procincoService.BuscarContenidoPorCursos(ConPc_Id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("CPCCursoBuscar/{curso}")]
        public IActionResult BuscarContenido(string curso)
        {
            var list = _procincoService.CPCBuscarCurso(curso);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("CPCContenidoBuscar/{contenido}")]
        public IActionResult Details(string contenido)
        {
            var list = _procincoService.CPCBuscarContenido(contenido);
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
