using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class HeaderFooter : PdfPageEventHelper
{
    private Image _logo;

    public HeaderFooter()
    {
        string logoPath = "https://ahm-honduras.com/procinco-new/wp-content/uploads/2022/05/PROCINCO-WHITE-1.png"; // Asegúrate de proporcionar la ruta correcta
        _logo = Image.GetInstance(logoPath);
        _logo.ScalePercent(25); // Ajusta el tamaño del logo según sea necesario
        _logo.SetAbsolutePosition(10, 760); // Posiciona el logo en el documento
    }

    // Método para agregar el encabezado
    public override void OnStartPage(PdfWriter writer, Document document)
    {
        document.Add(_logo);
    }

    // Método para agregar el pie de página
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        PdfPTable footerTbl = new PdfPTable(1);
        footerTbl.TotalWidth = 300;
        footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

        PdfPCell cell = new PdfPCell(new Phrase("Page " + document.PageNumber, FontFactory.GetFont("Arial", 12, Font.ITALIC)));
        cell.Border = 0;
        cell.PaddingLeft = 10;

        footerTbl.AddCell(cell);
        footerTbl.WriteSelectedRows(0, -1, 415, 30, writer.DirectContent);
    }
}