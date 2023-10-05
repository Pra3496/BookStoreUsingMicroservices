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

        private readonly ICartService cartService;


        public OrderRepository(ContextDB contextDB, IUserService userService, IBookService bookService, ICartService cartService)
        {

            this.contextDB = contextDB;
            this.bookService = bookService;
            this.userService = userService;
            this.cartService = cartService;

        }


        /// <summary>
        /// The Method is used to Add order from database.
        /// </summary>
        /// <param name="model">This Model has All parameters needed to add order.</param>
        /// <returns>Order object from database.</returns>
        public async Task<OrderEntity> AddOrder(OrderModel model, string token)
        {
            try
            {
                OrderEntity orderEntity = new OrderEntity();
                
                orderEntity.UserId = model.UserId;

                List<CartEntity> result = await this.cartService.GetCartFromApi(token);
                
                if (result.Count != 0)
                {
                    List<BookEntity> bookList = new();
                    decimal price = 0;
                    foreach (var item in result)
                    {
                        BookEntity book = await bookService.GetBookByIdFromApi(item.BookId);
                        price = price + (book.DiscountPrice * book.Quantity);
                        bookList.Add(book);
                    }

                    orderEntity.books = bookList;
                    orderEntity.GrandTotal = (float)price;
                    orderEntity.IsPaid = false;


                    orderEntity.user = await userService.GetUserByIdFromApi(model.UserId);


                    await contextDB.Orders.AddAsync(orderEntity);

                    await contextDB.SaveChangesAsync();
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


        public async Task<bool> PlaceOrder(long OrderId, string token)
        {
            try
            {
                var order = await contextDB.Orders.FirstOrDefaultAsync(x => x.OrderId == OrderId);

                if(order != null)
                {
                    List<CartEntity> result = await this.cartService.GetCartFromApi(token);

                    foreach (var item in result)
                    {

                        BookEntity book = await bookService.GetBookByIdFromApi(item.BookId);

                        OrderItemEntity orderItemEntity = new OrderItemEntity();
                        orderItemEntity.OrderId = OrderId;

                        orderItemEntity.bookId = book.BookId;
                        orderItemEntity.Qty = book.Quantity;


                        await contextDB.OrderItems.AddAsync(orderItemEntity);

                        await contextDB.SaveChangesAsync();

                    }

                    order.IsPaid = true;
                    contextDB.Orders.Update(order);
                    await contextDB.SaveChangesAsync();

                    await cartService.UpdateCartFromApi(token);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
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


                if (orders.Count != 0)
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

        public async Task<IEnumerable<OrderItemEntity>> GetAllOrdersItems()
        {

            try
            {
                var ordersItems = await contextDB.OrderItems.ToListAsync();


                if (ordersItems.Count != 0)
                {
                    return ordersItems;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<List<OrderEntity>> GetAllOrdersItemsUserPlacesed(long userId)
        {
            try
            {
               
                List<OrderEntity> orders = await contextDB.Orders.Where(x=> x.UserId == userId).ToListAsync();
    
                if (orders.Count != 0)
                {

                   foreach(var order in orders)
                   {
                        var orderItems = await contextDB.OrderItems.Where(x=> x.OrderId == order.OrderId).ToListAsync();
                        List<BookEntity> bookList = new();
                        decimal price = 0;
                        foreach (var item in orderItems)
                        {
                            BookEntity book = await bookService.GetBookByIdFromApi(item.bookId);
                            price = price + (book.DiscountPrice * book.Quantity);
                            bookList.Add(book);
                        }

                        order.books = bookList;
                        order.user = await userService.GetUserByIdFromApi(userId);
                   }

                    return orders;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
