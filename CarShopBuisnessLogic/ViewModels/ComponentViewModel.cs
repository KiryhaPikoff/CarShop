using CarShopBuisnessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace CarShopBuisnessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class ComponentViewModel : BaseViewModel
    {
        [Column(title: "Название компонента", width: 150)]
        public string ComponentName { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ComponentName" };
    }
}