using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using SistemaProcinco.BusinessLogic.Services;
using AutoMapper;
using SistemaProcinco.Entities.Entities;
using System.IO;

namespace SistemaProcinco.API
{
    public class crearPDF
    {

        public byte[] CursosImpartidosPdf(List<tbCursosImpartidos> cursosimpartidos)
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 10);
            var titleFont = new XFont("Verdana", 12, XFontStyle.Bold);
            var yPos = 40;

            // Encabezado
            gfx.DrawString("Listado de Cursos Impartidos", titleFont, XBrushes.Black, new XRect(0, yPos, page.Width, page.Height), XStringFormats.TopCenter);

            // Dibujar tabla
            yPos += 20;
            gfx.DrawString("ID | Curso | Instructor | Fecha de Inicio | Fecha de Fin | Usuario Finalización | Finalizado", font, XBrushes.Black, new XRect(10, yPos, page.Width, page.Height), XStringFormats.TopLeft);
            yPos += 20;

            foreach (var curso in cursosimpartidos)
            {
                var text = $"{curso.CurIm_Id} | {curso.Cursos} | {curso.Nombre} | {curso.CurIm_FechaInicio:dd/MM/yyyy} | {curso.CurIm_FechaFin:dd/MM/yyyy} | {curso.CurIm_UsuarioFinalizacion} | {(curso.CurIm_Finalizar.HasValue ? (curso.CurIm_Finalizar.Value ? "Sí" : "No") : "No especificado")}";
                gfx.DrawString(text, font, XBrushes.Black, new XRect(10, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
            }

            using (var stream = new MemoryStream())
            {
                document.Save(stream);
                return stream.ToArray();
            }
        }



    }
}
