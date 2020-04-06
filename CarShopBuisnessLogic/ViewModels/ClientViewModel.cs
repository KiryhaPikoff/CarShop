using System.ComponentModel;
using System.Runtime.Serialization;

namespace CarShopBuisnessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("ФИО")]
        public string ClientFio { get; set; }

        [DataMember]
        [DisplayName("ФИО")]
        public string Login { get; set; }

        [DataMember]
        [DisplayName("ФИО")]
        public string Password { get; set; }
    }
}
