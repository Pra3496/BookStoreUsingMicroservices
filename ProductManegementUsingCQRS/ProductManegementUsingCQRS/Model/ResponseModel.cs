namespace ProductManegementUsingCQRS.Model
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; } = "Execution is Unsuccessfull";

        public object Data { get; set; }
    }
}
