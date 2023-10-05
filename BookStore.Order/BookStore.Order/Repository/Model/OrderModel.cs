using Newtonsoft.Json;

namespace BookStore.Order.Repository.Model
{
    public class OrderModel
    {
        [JsonIgnore]
        public long OrderId { get; set; }

        public long UserId { get; set; }

        public float GrandTotal { get; set; }

        public bool IsPaid { get; set; }
    }
}
