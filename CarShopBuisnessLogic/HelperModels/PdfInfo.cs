﻿using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    abstract class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
    }
}