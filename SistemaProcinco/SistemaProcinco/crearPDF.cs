using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class PdfFooterHelper : PdfPageEventHelper
{
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        PdfPTable footer = new PdfPTable(1);
        footer.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
        footer.DefaultCell.Border = 0;
        footer.AddCell(new PdfPCell(new Phrase("Página " + writer.PageNumber, new Font(Font.FontFamily.HELVETICA, 8)))
        {
            HorizontalAlignment = Element.ALIGN_CENTER,
            Border = Rectangle.NO_BORDER,
            PaddingTop = 10
        });
        footer.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 10, writer.DirectContent);
    }
}