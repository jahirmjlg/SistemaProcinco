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
    public class CursosController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public CursosController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaCursos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("CursosCrear")]
        public IActionResult Insert(CursosViewModel item)
        {
            var model = _mapper.Map<tbCursos>(item);
            var modelo = new tbCursos()
            {
                Curso_Descripcion = item.Curso_Descripcion,
                Curso_DuracionHoras = item.Curso_DuracionHoras,
                Curso_Imagen = item.Curso_Imagen,
                Cate_Id = item.Cate_Id,
                Curso_UsuarioCreacion = 1,
                Curso_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("CursosEditar")]
        public IActionResult Edit(CursosViewModel item)
        {
            var model = _mapper.Map<tbCursos>(item);
            var modelo = new tbCursos()
            {
                Curso_Id = item.Curso_Id,
                Curso_Descripcion = item.Curso_Descripcion,
                Curso_DuracionHoras = item.Curso_DuracionHoras,
                Curso_Imagen = item.Curso_Imagen,
                Cate_Id = item.Cate_Id,
                Curso_UsuarioModificacion = 1,
                Curso_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }


        [HttpDelete("CursoEliminar")]
        public IActionResult Delete(int Curso_Id)
        {
            var list = _procincoService.EliminarCursos(Curso_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("CursosBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _procincoService.BuscarCursos(id);
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
