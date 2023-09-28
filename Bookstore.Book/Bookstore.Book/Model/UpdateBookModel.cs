namespace Bookstore.Book.Model
{
    public class UpdateBookModel
    {
        public string BookName { get; set; }

        public string Author { get; set; }

        public string Discription { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }

        public int Quantity { get; set; }

        public int AvalableQuantity { get; set; }

        public string Image { get; set; }
    }
}
