namespace BookStore.Order.Repository.Interface
{
    public interface ICartService
    {
        Task<List<CartEntity>> GetCartFromApi(string Token);

        Task<bool> UpdateCartFromApi(string Token);
    }
}
