using DocumentFormat.OpenXml.Drawing;
using MigraDoc.DocumentObjectModel;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class PdfRowParameters
    {
        public Table Table { get; set; }
        public List<string> Texts { get; set; }
        public string Style { get; set; }
        public ParagraphAlignment ParagraphAlignment { get; set; }
    }
}