using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ITextSoEvent
/// </summary>
namespace Comman
{
    public class ITextSoEvent : PdfPageEventHelper
    {
        public string LocationName = string.Empty; string pdfpathfoot = string.Empty;
        public ITextSoEvent()
        {           
        }

        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;


        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion


        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            //iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.f.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            //iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);



            string pdfpath = HttpContext.Current.Server.MapPath(".") + "/images/logo_tagline.png";

            Image image = iTextSharp.text.Image.GetInstance(pdfpath);

           // Phrase p1Header = new Phrase("PURCHASED ORDER");

            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);

            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            PdfPCell pdfCell1 = new PdfPCell();
            PdfPCell pdfCell2 = new PdfPCell(image);
            PdfPCell pdfCell3 = new PdfPCell();

            PdfPCell pdfCell4 = new PdfPCell();
            PdfPCell pdfCell5 = new PdfPCell();
            PdfPCell pdfCell6 = new PdfPCell();
            LocationName = HttpContext.Current.Session["LocationName"].ToString();

            if (LocationName == "Centillion Bangalore")
            {
                pdfpathfoot = HttpContext.Current.Server.MapPath(".") + "/images/sales_Bengaluru.png";
            }
            else if (LocationName == "Centillion  Chennai")
            {
                pdfpathfoot = HttpContext.Current.Server.MapPath(".") + "/images/sales_Chennai.png";
            }
            else if (LocationName == "Centillion  Delhi")
            {
                pdfpathfoot = HttpContext.Current.Server.MapPath(".") + "/images/sales_Delhi.png";
            }
            else
            {
                pdfpathfoot = HttpContext.Current.Server.MapPath(".") + "/images/sales3.png";
            }

            //string pdfpathfoot = HttpContext.Current.Server.MapPath(".") + "/images/sales3.png";

            Image imagefoot = iTextSharp.text.Image.GetInstance(pdfpathfoot);

            //String text = "Page " + writer.PageNumber + " of ";


            ////Add paging to header
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 12);
            //    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
            //    cb.ShowText(text);

            //    cb.EndText();
            //    float len = bf.GetWidthPoint(text, 12);
            //    //Adds "12" in Page 1 of 12
            //    cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
            //}
            ////Add paging to footer
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 12);
            //    cb.SetTextMatrix(document.PageSize.GetRight(180), document.PageSize.GetBottom(30));
            //    cb.ShowText(text);
            //    cb.EndText();
            //    float len = bf.GetWidthPoint(text, 12);
            //    cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
            //}
            //Row 2

            //Row 3
            

            //set the alignment of all three cells and set border to 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_TOP;
            pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;



            pdfCell1.HorizontalAlignment = Element.ALIGN_TOP;
            pdfCell2.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell4.VerticalAlignment = Element.ALIGN_CENTER;
            pdfCell5.VerticalAlignment = Element.ALIGN_CENTER;
            pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE;


            pdfCell2.Colspan = 3;
           // pdfCell5.Colspan = 3;
            
            pdfCell2.Border = 0;
            pdfCell3.Border = 0;
            pdfCell4.Border = 0;
            pdfCell5.Border = 0;
            pdfCell6.Border = 0;


            //add all three cells into PdfTable

            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(pdfCell3);
            pdfTab.AddCell(pdfCell4);

            pdfTab.AddCell(pdfCell5);
            pdfTab.AddCell(pdfCell6);


            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 70;
            //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;


            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);


            //PdfPTable table = new PdfPTable(3);

            //PdfPCell cell0 = new PdfPCell(image);
            //cell0.Colspan = 3;
            //cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(cell0);
            //table.AddCell("");

            //PdfPCell cell = new PdfPCell(new Phrase("Centillion Solutions and Services Pvt Ltd.\n iliyas"));
            //cell.Colspan = 3;
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(cell);
            //table.AddCell("");

            //PdfPCell cell1 = new PdfPCell(new Phrase("CIN:U72400KA2006PTC039877"));
            //cell1.Colspan = 3;
            //cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(cell1);
            //table.AddCell("Row 2, Col 1");
            //table.AddCell("Row 2, Col 1");

            //table.AddCell("Row 3, Col 1");
            //cell = new PdfPCell(new Phrase("Row 3, Col 2 and Col3"));
            //cell.Colspan = 2;
            //table.AddCell(cell);

            //cell = new PdfPCell(new Phrase("Row 4, Col 1 and Col2"));
            //cell.Colspan = 2;
            //table.AddCell(cell);
            //table.AddCell("Row 4, Col 3");
            
            PdfPTable pdfTabfooter = new PdfPTable(2);
            //Row 1
            PdfPCell pdfCellfoot1 = new PdfPCell(imagefoot);
            
            PdfPCell pdfCellfoot2 = new PdfPCell();

            pdfCellfoot1.Border = 0;
            pdfCellfoot2.Border = 0;

            pdfCellfoot1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCellfoot2.HorizontalAlignment = Element.ALIGN_LEFT;


            pdfCellfoot1.VerticalAlignment = Element.ALIGN_CENTER;
            pdfCellfoot2.VerticalAlignment = Element.ALIGN_CENTER;


            pdfCellfoot1.Colspan = 3;
            pdfTabfooter.AddCell(pdfCellfoot1);


            var a = document.PageSize.Bottom;
            pdfTabfooter.TotalWidth = document.PageSize.Width;
            //pdfTabfooter.WidthPercentage = 70;

            pdfTabfooter.WriteSelectedRows(0, -1, 0, document.PageSize.GetBottom(120), writer.DirectContent);
            

            //footer.writeSelectedRows(0, -1, 36, 64, writer.DirectContent);
            //set pdfContent value

            //Move the pointer and draw line to separate header section from rest of page
            cb.MoveTo(40, document.PageSize.Height - 100);
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
            cb.Stroke();

            //Move the pointer and draw line to separate footer section from rest of page
            cb.MoveTo(40, document.PageSize.GetBottom(70));


            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 12);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 12);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();


        }
    }
}