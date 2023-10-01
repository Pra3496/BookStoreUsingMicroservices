namespace ProductManegementQuary.Model
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; } = "Execution is Unuccessfull";

        public object Data { get; set; }

    }
}
