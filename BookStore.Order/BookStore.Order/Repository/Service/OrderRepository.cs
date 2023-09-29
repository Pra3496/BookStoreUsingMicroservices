using BookStore.Order.Repository.Interface;
using BookStore.Order.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Order.Repository.Service
{
    public class OrderRepository : IOrderRepository
    {
       
        private readonly ContextDB contextDB;

        private readonly IBookService bookService;

        private readonly IUserService userService;


        public OrderRepository(ContextDB contextDB, IUserService userService, IBookService bookService)
        {

            this.contextDB = contextDB;
            this.bookService = bookService;
            this.userService = userService;

        }


        /// <summary>
        /// The Method is used to Add order from database.
        /// </summary>
        /// <param name="model">This Model has All parameters needed to add order.</param>
        /// <returns>Order object from database.</returns>
        public async Task<OrderEntity> AddOrder(OrderModel model)
        {
            try
            {
                OrderEntity orderEntity = new OrderEntity();

                orderEntity.BookId = model.BookId;
                orderEntity.UserId = model.UserId;

                orderEntity.Quantity = model.Quantity;

                orderEntity.book = await bookService.GetBookByIdFromApi(model.BookId);
                orderEntity.user = await userService.GetUserByIdFromApi(model.UserId);
                

                await contextDB.Orders.AddAsync(orderEntity);

                await contextDB.SaveChangesAsync();


                if (orderEntity != null)
                {
                    return orderEntity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// This method retrive all order from database.
        /// </summary>
        /// <returns>List of Orders</returns>
        public async Task<IEnumerable<OrderEntity>> GetAllOrders()
        {

            try
            {
                var orders = await contextDB.Orders.ToListAsync();


                if (orders != null)
                {
                    return orders;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
