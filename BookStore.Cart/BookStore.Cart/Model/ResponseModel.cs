using BookStore.Cart.Repository;

namespace BookStore.Cart.Model
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; } = "Execution Unsuccessful";

        public object Data { get; set; }

        public List<CartEntity> DataList { get; set; }
    }
}
