using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Book.Repository
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BookId { get; set; }

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
