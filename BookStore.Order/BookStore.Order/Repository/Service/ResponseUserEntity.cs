namespace BookStore.Order.Repository.Service
{
    public class ResponseUserEntity
    {
        public bool isSuccess { get; set; }

        public string message { get; set; } 

        public UserEntity data { get; set; }
    }
}
