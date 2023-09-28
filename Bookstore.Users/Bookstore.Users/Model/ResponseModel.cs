namespace Bookstore.User.Model
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = "Execution Successful";

        public object Data { get; set; }


    }
}
