using System.ComponentModel.DataAnnotations;

namespace ProductManegementUsingCQRS.Model
{
    public class CommandModel
    {
       // [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Product name must contain only letters, digits, and spaces.")]
        public string ProductName { get; set; }



       // [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Qty { get; set; }



       // [Range(0.0, float.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }



        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Added by must contain only letters and spaces.")]
        public string AddedBy { get; set; }



        public DateTime AddedOn { get; set; }
    }

}
