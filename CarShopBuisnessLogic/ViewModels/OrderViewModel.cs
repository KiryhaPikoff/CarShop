using CarShopBuisnessLogic.Attributes;
using CarShopBuisnessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CarShopBuisnessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string CarName { get; set; }
        [Column(title: "Исполнитель", width: 70)]
        [DataMember]
        public string ImplementerFIO { get; set; }

        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 80)]
        [DataMember]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создания", width: 100)]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 100)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
        public override List<string> Properties() => new List<string> { "Id",
        "ClientFIO", "CarName", "ImplementerFIO", "Count", "Sum", "Status", "DateCreate",
        "DateImplement" };
    }
}