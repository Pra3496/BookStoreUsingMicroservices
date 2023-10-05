using BookStore.Order.Repository.Model;

namespace BookStore.Order.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<OrderEntity> AddOrder(OrderModel model, string token);
        

        Task<bool> PlaceOrder(long OrderId, string token);

        Task<IEnumerable<OrderEntity>> GetAllOrders();
        Task<IEnumerable<OrderItemEntity>> GetAllOrdersItems();

        Task <List<OrderEntity>> GetAllOrdersItemsUserPlacesed(long userId);
    }
}
