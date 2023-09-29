namespace BookStore.Order.Repository.Interface
{
    public interface IUserService
    {
        Task<UserEntity> GetUserByIdFromApi(long userId);
    }
}
