namespace BookStore.Order.Repository.Service
{
    public class ResponseEntity
    {
        public bool isSuccess { get; set; }

        public string message { get; set; }

        public BookEntity data { get; set; }
    }
}
