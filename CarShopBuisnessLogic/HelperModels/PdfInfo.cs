﻿using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportCarViewModel> Cars { get; set; }
    }
}