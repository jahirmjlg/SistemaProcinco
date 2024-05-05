using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaProcinco.BusinessLogic.Services;
using SistemaProcinco.Common.Models;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;


namespace SistemaProcinco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursosImpartidosController : Controller
    {
        private readonly ProcincoService _procincoService;

        private readonly crearPDF _crearpdf;
        private readonly IMapper _mapper;

        public CursosImpartidosController(ProcincoService procincoService, IMapper mapper, crearPDF crearpdf)
        {
            _procincoService = procincoService;
            _mapper = mapper;
            _crearpdf = crearpdf;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaCursosImpartidos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }


        [HttpGet("ListadoPDF")]
        public IActionResult GetCoursesAsPdf()
        {
            var listado = _procincoService.ListaCursosImpartidos();
            if (listado.Success)
            {
                var pdfBytes = _crearpdf.CursosImpartidosPdf(listado.Data);
                return File(pdfBytes, "application/pdf", "ListadoCursos.pdf");
            }
            else
            {
                return Problem("Error al obtener los cursos.");
            }
        }



        [HttpPost("CursoImpartidoCrear")]
        public IActionResult Insert(CursosImpartidosViewModel item)
        {
            var model = _mapper.Map<tbCursosImpartidos>(item);
            var modelo = new tbCursosImpartidos()
            {
                Curso_Id = item.Curso_Id,
                Empl_Id = item.Empl_Id,
                CurIm_FechaInicio = item.CurIm_FechaInicio,
                CurIm_FechaFin = item.CurIm_FechaFin,
                CurIm_UsuarioFinalizacion = item.CurIm_UsuarioFinalizacion,
                CurIm_Finalizar = item.CurIm_Finalizar,
                CurIm_UsuarioCreacion = 1,
                CurIm_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarCursosImpartidos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("CursoImpartidoEditar")]
        public IActionResult Edit(CursosImpartidosViewModel item)
        {
            var model = _mapper.Map<tbCursosImpartidos>(item);
            var modelo = new tbCursosImpartidos()
            {
                CurIm_Id = item.CurIm_Id,
                Curso_Id = item.Curso_Id,
                Empl_Id = item.Empl_Id,
                CurIm_FechaInicio = item.CurIm_FechaInicio,
                CurIm_FechaFin = item.CurIm_FechaFin,
                CurIm_UsuarioFinalizacion = item.CurIm_UsuarioFinalizacion,
                CurIm_Finalizar = item.CurIm_Finalizar,
                CurIm_UsuarioModificacion = 1,
                CurIm_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarCursosImpartidos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("CursosImpartidosEliminar")]
        public IActionResult Delete(int CurIm_Id)
        {
            var list = _procincoService.EliminarCursosImpartidos(CurIm_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("CursoImpartidoBuscar")]
        public IActionResult Details(int CurIm_Id)
        {
            var list = _procincoService.BuscarCursosImpartidos(CurIm_Id);
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
