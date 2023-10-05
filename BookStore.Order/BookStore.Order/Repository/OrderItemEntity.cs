using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore.Order.Repository
{
    public class OrderItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderItemId { get; set; }

        public long bookId { get; set; }


        public int Qty { get; set; }


        [ForeignKey("Orders")]
        public long OrderId { get; set; }

        [JsonIgnore]
        public virtual OrderEntity Orders { get; set; }

    }
}
