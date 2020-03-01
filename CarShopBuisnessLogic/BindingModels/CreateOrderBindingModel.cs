namespace CarShopBuisnessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int CarId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}