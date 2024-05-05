﻿using AutoMapper;
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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace SistemaProcinco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursosImpartidosController : Controller
    {
        private readonly ProcincoService _procincoService;

        
        private readonly IMapper _mapper;

        public CursosImpartidosController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
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

        [HttpGet]
        [Route("api/preview-pdf")]
        public IActionResult PreviewPDF()
        {

            MemoryStream memoryStream = CreatePdfStream();
            memoryStream.Position = 0;
            return new FileStreamResult(memoryStream, "application/pdf");
        }



        private MemoryStream CreatePdfStream()
        {

            MemoryStream memoryStream = new MemoryStream();

            Document document = new Document(PageSize.A4, 50, 50, 80, 60);
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            writer.CloseStream = false; 

            document.Open();

            Font font = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            PdfPTable table = new PdfPTable(7);
            var headers = new string[] { "ID", "Curso", "Nombre", "Fecha Inicio", "Fecha Fin", "Usuario Finalización", "Finalizado" };
            foreach (var header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, font));
                cell.BackgroundColor = new BaseColor(153, 102, 204);
                table.AddCell(cell);
            }

            var listado = _procincoService.ListaCursosImpartidos();
            if (listado.Data != null)
            {
                foreach (var curso in listado.Data)
                {
                    table.AddCell(new Phrase(curso.CurIm_Id.ToString(), font));
                    table.AddCell(new Phrase(curso.Cursos, font));
                    table.AddCell(new Phrase(curso.Nombre, font));
                    table.AddCell(new Phrase(curso.CurIm_FechaInicio.ToString("dd/MM/yyyy"), font));
                    table.AddCell(new Phrase(curso.CurIm_FechaFin.ToString("dd/MM/yyyy"), font));
                    table.AddCell(new Phrase(curso.CurIm_UsuarioFinalizacion.ToString(), font));
                    table.AddCell(new Phrase(curso.CurIm_Finalizar ? "Sí" : "No", font));
                }
            }

            document.Add(table);
            document.Close(); 

            memoryStream.Position = 0; 
            return memoryStream;
        }



        

        [HttpGet("Preview")]
        public ActionResult GenerateCoursesPdf()
        {
            MemoryStream memoryStream = CreatePdfStream();
            memoryStream.Position = 0;

            return new FileStreamResult(memoryStream, "application/pdf")
            {
                FileDownloadName = "ReporteCursos.pdf"
            };
        }
















        // /////////




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
