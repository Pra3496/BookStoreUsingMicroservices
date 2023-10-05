namespace BookStore.Order.Repository.Model
{
    public class ResponseModelCart
    {
        public bool isSuccess { get; set; } = true;

        public string message { get; set; } = "Execution Successful";

        public List<CartEntity> data { get; set; }
    }
}
