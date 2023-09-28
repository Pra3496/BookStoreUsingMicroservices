using BookStore.Order.Repository.Model;

namespace BookStore.Order.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<OrderEntity> AddOrder(OrderModel model);
        Task<IEnumerable<OrderEntity>> GetAllOrders();
    }
}
