using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Order.Repository
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }

        public long UserId { get; set; }

        public float GrandTotal { get; set; }

        public bool IsPaid { get; set; }


        [NotMapped]
        public List<BookEntity> books{ get; set; }

        [NotMapped]
        public UserEntity user {get; set;}

    }
}
