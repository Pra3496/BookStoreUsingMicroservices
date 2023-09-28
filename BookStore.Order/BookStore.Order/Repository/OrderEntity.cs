using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Order.Repository
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }

        public long BookId { get; set; }

        public long UserId { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public BookEntity book { get; set; }

        [NotMapped]
        public UserEntity user {get; set;}

    }
}
