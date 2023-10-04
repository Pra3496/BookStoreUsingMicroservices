using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Cart.Repository
{
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CartId { get; set; }

        public long BookId { get; set; }

        public long UserId { get; set; }

        public bool IsPurchesed { get; set; }

        public int Qty { get; set; }
    }
}
