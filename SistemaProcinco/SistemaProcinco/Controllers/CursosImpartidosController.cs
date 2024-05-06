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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using iTextSharp.tool.xml;

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

        // DASH
        [HttpGet("CursosMes")]
        public IActionResult CursosMes()
        {
            var listado = _procincoService.CursosImpartidosMes();
            if (listado.Success == true)
            {
                return Ok(listado.Data);
            }
            else
            {
                return Problem();
            }
        }





        private MemoryStream CreatePdfStream()
        {
            MemoryStream memoryStream = new MemoryStream();

            using (Document document = new Document())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                writer.CloseStream = false;

                document.Open();

                string css = @"
        <style> 
            body { font-family: 'Arial'; font-size: 10pt; }
            table { width: 100%; border-collapse: collapse; margin-top: 20px; }
            th, td { border: 1px solid #ccc; padding: 8px; text-align: left; }
            th { background-color: #633394; color: #ffffff; } // Color de encabezado personalizado
            td { background-color: #f9f9f9; color: #333; }  // Mejora en el color de fondo de la celda
            .header, .footer { width: 100%; background-color: #633394; color: white; text-align: center; padding: 10px 0; }
            .footer { position: fixed; bottom: 0; }
        </style>";

                string htmlContent = @"
        <html>
        <head>
        </head>
        <body>
            <div class='header'>
                <img src='https://ahm-honduras.com/procinco-new/wp-content/uploads/2022/05/PROCINCO-COLOR-1.png' alt='Logo' style='width: 100px; height: auto;' />
                <h1>Reporte de Cursos Impartidos</h1>
            </div>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Curso</th>
                        <th>Nombre</th>
                        <th>Fecha Inicio</th>
                        <th>Fecha Fin</th>
                        <th>Finalizado</th>
                    </tr>
                </thead>
                <tbody>";

                var listado = _procincoService.ListaCursosImpartidos();
                foreach (var curso in listado.Data)
                {
                    
                    if(curso.CurIm_FechaFin != null)
                    {
                        htmlContent += $@"
                        <tr>
                            <td>{curso.CurIm_Id}</td>
                            <td>{curso.Cursos}</td>
                            <td>{curso.Nombre}</td>
                            <td>{curso.CurIm_FechaInicio:dd/MM/yyyy}</td>
                            <td>{curso.CurIm_FechaFin:dd/MM/yyyy}</td>
                            <td>{(curso.CurIm_Finalizar ? "Sí" : "No")}</td>
                        </tr>";
                    }
                    else
                    {
                        htmlContent += $@"
                        <tr>
                            <td>{curso.CurIm_Id}</td>
                            <td>{curso.Cursos}</td>
                            <td>{curso.Nombre}</td>
                            <td>{curso.CurIm_FechaInicio:dd/MM/yyyy}</td>
                            <td style='color: #14b81b'>Sin Finalizar</td>
                            <td>{(curso.CurIm_Finalizar ? "Sí" : "No")}</td>
                        </tr>";
                    }

                }

                htmlContent += @"
                </tbody>
            </table>
            <div class='footer'>
                <p>© 2024 Procinco. Todos los derechos reservados.</p>
            </div>
        </body>
        </html>";

                using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(css)))
                using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, msHtml, msCss);
                }

                document.Close();
            }

            memoryStream.Position = 0;
            return memoryStream;
        }




        private static readonly Dictionary<string, byte[]> _pdfCache = new Dictionary<string, byte[]>();

        [HttpGet("Preview")]
        public ActionResult GeneratePreviewPdf()
        {
            MemoryStream pdfStream = CreatePdfStream();
            pdfStream.Position = 0;
            var pdfBytes = pdfStream.ToArray();

            var fileId = Guid.NewGuid().ToString();
            _pdfCache[fileId] = pdfBytes;


            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var url = Url.Action("GetPdfFile", new { fileId = fileId });
            var fullUrl = baseUrl + url;

            return Ok(fullUrl);
        }

        [HttpGet("GetPdfFile/{fileId}")]
        public ActionResult GetPdfFile(string fileId)
        {
            if (_pdfCache.TryGetValue(fileId, out var pdfBytes))
            {
                Response.Headers.Add("Content-Disposition", "inline");
                return File(pdfBytes, "application/pdf");
            }

            return NotFound();
        }


        [HttpGet("DownloadPdf/{fileId}")]
        public ActionResult DownloadPdf(string fileId)
        {
            if (_pdfCache.TryGetValue(fileId, out var pdfBytes))
            {
                return File(pdfBytes, "application/pdf", "Download_ReporteCursos.pdf");
            }

            return NotFound();
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
