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




        public class PdfFooterHelper : PdfPageEventHelper
        {
            private readonly string _footerText;

            public PdfFooterHelper(string footerText)
            {
                _footerText = footerText;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfPTable footer = new PdfPTable(2);
                footer.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                footer.DefaultCell.Border = 0;

                PdfPCell footerTextCell = new PdfPCell(new Phrase(_footerText, new Font(Font.FontFamily.HELVETICA, 8)));
                footerTextCell.HorizontalAlignment = Element.ALIGN_LEFT;
                footerTextCell.Border = Rectangle.NO_BORDER;

                PdfPCell pageNumberCell = new PdfPCell(new Phrase($"Página {writer.PageNumber}", new Font(Font.FontFamily.HELVETICA, 8)));
                pageNumberCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                pageNumberCell.Border = Rectangle.NO_BORDER;

                footer.AddCell(footerTextCell);
                footer.AddCell(pageNumberCell);

                footer.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 10, writer.DirectContent);
            }
        }




        private MemoryStream CreatePdfStream(string footerText = "Usuario Creacion")
        {
            MemoryStream memoryStream = new MemoryStream();

            using (Document document = new Document(PageSize.A4, 30, 30, 75, 45)) // Ajustar márgenes para encabezado y pie de página
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                writer.CloseStream = false;

                // Evento para pie de página con texto adicional
                writer.PageEvent = new PdfFooterHelper(footerText);

                document.Open();

                string css = @"
        <style> 
            body { font-family: 'Arial'; font-size: 10pt; }
            table { width: 100%; border-collapse: collapse; margin-top: 30px; }
            th, td { border: 1px solid #ccc; padding: 8px; text-align: left; background-color: #f9f9f9; color: #333; }
            th { background-color: #633394; color: #ffffff; }
            .header { text-align: center; margin-bottom: 20px; }
            .header img { width: 150px; height: auto; }
            .title { font-size: 20pt; font-weight: bold; color: #633394; margin-top: 10px; }
            .footer { text-align: center; background-color: #633394; color: white; padding: 10px 0; }
        </style>";

                string htmlContent = @"
        <html>
        <head>
        </head>
        <body>
            <div class='header'>
                <img src='https://ahm-honduras.com/procinco-new/wp-content/uploads/2022/05/PROCINCO-COLOR-1.png' alt='Logo' />
                <div class='title'>Reporte de Cursos Impartidos</div>
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
                    if (curso.CurIm_FechaFin != null)
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




        [HttpPost("Crear")]
        public IActionResult Insert(CursosImpartidosViewModel item)
        {
            var model = _mapper.Map<tbCursosImpartidos>(item);
            var modelo = new tbCursosImpartidos()
            {
                Curso_Id = item.Curso_Id,
                Empl_Id = item.Empl_Id,
                CurIm_FechaInicio = item.CurIm_FechaInicio,
                CurIm_FechaFin = item.CurIm_FechaFin,
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

        [HttpPut("Editar")]
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

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var list = _procincoService.EliminarCursosImpartidos(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpPut("Finalizar/{id}")]
        public IActionResult Finalizar(CursosImpartidosViewModel item, int id)
        {
            item.CurIm_Id = id;
            var model = _mapper.Map<tbCursosImpartidos>(item);
            var modelo = new tbCursosImpartidos()
            {
                CurIm_Id = item.CurIm_Id,
                CurIm_UsuarioFinalizacion = 1,
            };
            var list = _procincoService.FinalizarCursosImpartidos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _procincoService.BuscarCursosImpartidos(id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }


        [HttpGet("BuscarEmpleado/{DNI}")]
        public IActionResult BuscarEmpleado(string DNI)
        {
            var list = _procincoService.BuscarEmpleado(DNI);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("BuscarCurso/{curso}")]
        public IActionResult BuscarCurso(string curso)
        {
            var list = _procincoService.BuscarCurso(curso);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("BuscarParticipante/{curso}")]
        public IActionResult BuscarParticipante(string curso)
        {
            var list = _procincoService.BuscarParticipante(curso);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }












        private MemoryStream CreatePdfFactura(int id)
        {
            MemoryStream memoryStream = new MemoryStream();

            using (Document document = new Document(PageSize.A4, 30, 30, 75, 45)) // Ajustar márgenes para encabezado y pie de página
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                writer.CloseStream = false;

                document.Open();

                string css = @"
        <style> 
            body { font-family: 'Arial'; font-size: 10pt; }
            .header { text-align: center; margin-bottom: 20px; }
            .header img { width: 150px; height: auto; }
            .title { font-size: 24pt; font-weight: bold; color: #633394; margin-top: 10px; }
            .invoice-details { margin-top: 20px; }
            .invoice-section { margin-bottom: 20px; }
            .invoice-section h2 { font-size: 14pt; font-weight: bold; color: #633394; margin-bottom: 10px; }
            .invoice-section p { margin: 0; padding: 5px 0; }
            .invoice-section p span { font-weight: bold; }
            .total { text-align: right; font-size: 12pt; font-weight: bold; margin-top: 10px; }
            .footer { text-align: center; background-color: #633394; color: white; padding: 10px 0; position: fixed; bottom: 0; left: 0; right: 0; height: 40px; }
        </style>";

                var listado = _procincoService.BuscarFactura(id);
                var curso = listado.Data[0];

                if (curso == null)
                {
                    throw new Exception("No se encontraron datos para el ID proporcionado.");
                }

                string htmlContent = $@"
        <html>
        <head>
        </head>
        <body>
            <div class='header'>
                <img src='https://ahm-honduras.com/procinco-new/wp-content/uploads/2022/05/PROCINCO-COLOR-1.png' alt='Logo' />
                <div class='title'>Factura</div>
            </div>
            <div class='invoice-details'>
                <div class='invoice-section'>
                    <h2>Detalles del Curso</h2>
                    <p><span>ID:</span> {curso.CurIm_Id}</p>
                    <p><span>Curso:</span> {curso.Cursos}</p>
                    <p><span>Nombre:</span> {curso.Nombre}</p>
                </div>
                <div class='invoice-section'>
                    <h2>Fechas</h2>
                    <p><span>Fecha Inicio:</span> {curso.CurIm_FechaInicio:dd/MM/yyyy}</p>
                    <p><span>Fecha Fin:</span> {curso.CurIm_FechaFin:dd/MM/yyyy}</p>
                </div>
                <div class='invoice-section'>
                    <h2>Pago</h2>
                    <p><span>Pago Total:</span> {curso.Empl_Total}</p>
                </div>
                <div class='total'>
                    <p>Total: {curso.Empl_Total}</p>
                </div>
            </div>
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












        [HttpGet("PreviewFactura/{id}")]
        public ActionResult GeneratePreviewFactura(int id)
        {
            MemoryStream pdfStream = CreatePdfFactura(id);
            pdfStream.Position = 0;
            var pdfBytes = pdfStream.ToArray();

            var fileId = Guid.NewGuid().ToString();
            _pdfCache[fileId] = pdfBytes;


            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var url = Url.Action("GetPdfFile", new { fileId = fileId });
            var fullUrl = baseUrl + url;

            return Ok(fullUrl);
        }


        [HttpGet("GetPdfFactura/{id}")]
        public ActionResult GetPdfFactura(string id)
        {
            if (_pdfCache.TryGetValue(id, out var pdfBytes))
            {
                Response.Headers.Add("Content-Disposition", "inline");
                return File(pdfBytes, "application/pdf");
            }

            return NotFound();
        }


        [HttpGet("DownloadPdfFactura/{fileId}")]
        public ActionResult DownloadPdfFactura(string fileId)
        {
            if (_pdfCache.TryGetValue(fileId, out var pdfBytes))
            {
                return File(pdfBytes, "application/pdf", "Download_FacturaCursoImpartido.pdf");
            }

            return NotFound();
        }

    }
}
