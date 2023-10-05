namespace BookStore.Order.Repository
{
    public class CartEntity
    {
        public long CartId { get; set; }

        public long BookId { get; set; }

        public long UserId { get; set; }

        public bool IsPurchesed { get; set; }

        public int Qty { get; set; }
    }
}
