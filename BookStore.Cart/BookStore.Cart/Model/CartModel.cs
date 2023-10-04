using System.Text.Json.Serialization;

namespace BookStore.Cart.Model
{
    public class CartModel
    {
        public long BookId { get; set; }

        [JsonIgnore]
        public long UserId { get; set; }

        public int Qty { get; set; }

        [JsonIgnore]
        public bool IsPurchesed { get; set; }
    }
}
