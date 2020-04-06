namespace CarShopBuisnessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}