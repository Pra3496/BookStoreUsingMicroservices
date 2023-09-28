namespace Bookstore.Book.Model
{
    public class ResponceModel
    {
        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = "Execution Successful";

        public object Data { get; set; }
    }
}
