using BookStore.Cart.Model;

namespace BookStore.Cart.Repository.Interface
{
    public interface ICartRepo
    {
        Task<CartEntity> AddToCart(CartModel model);

        Task<IEnumerable<CartEntity>> GetAllCart(long userId); 

       
        Task<bool> DeleteById(long CartId);

        Task<IEnumerable<CartEntity>> GetAllCartWhichOrder(long userId);

        Task<bool> UpdateAllCartWhichOrdered(long userId);

    }
}
