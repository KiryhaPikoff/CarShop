using DocumentFormat.OpenXml.Spreadsheet;
using MigraDoc.DocumentObjectModel;

namespace CarShopBuisnessLogic.HelperModels
{
    class PdfCellParameters
    {
        public Cell Cell { get; set; }
        public string Text { get; set; }
        public string Style { get; set; }
        public ParagraphAlignment ParagraphAlignment { get; set; }
        public Unit BorderWidth { get; set; }

    }
}