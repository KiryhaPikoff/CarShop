﻿using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopBuisnessLogic.HelperModels
{
    abstract class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
    }
}
