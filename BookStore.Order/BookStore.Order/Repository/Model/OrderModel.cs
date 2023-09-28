using Newtonsoft.Json;

namespace BookStore.Order.Repository.Model
{
    public class OrderModel
    {
        [JsonIgnore]
        public long OrderId { get; set; }


        public long BookId { get; set; }

        [JsonIgnore]
        public long UserId { get; set; }

        public int Quantity { get; set; } 
    }
}
