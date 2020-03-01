namespace CarShopBuisnessLogic.BindingModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления машины
    /// </summary>
    public class ComponentBindingModel
    {
        public int? Id { get; set; }
        public string ComponentName { get; set; }
    }
}