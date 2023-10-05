using BookStore.Order.Repository.Interface;
using BookStore.Order.Repository.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        private ResponceModel response;
        public OrdersController(IOrderRepository repository)
        {
            this.orderRepository = repository;
            this.response = new ResponceModel();
        }


        /// <summary>
        /// This Method Used to Add Order.
        /// </summary>
        /// <param name="model">This model has all parameters needed to Add Order</param>
        /// <returns>Responce model with Message and object of order</returns>
        [Authorize]
        [HttpPost]
        public async Task<ResponceModel> AddOrder()
        {
            
            try
            {
                OrderModel model = new();

                long userId = long.Parse(User.FindFirst("UserID").Value);
                string token = Request.Headers.Authorization.ToString();

                model.UserId = userId;


                if (userId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Authorization is Unsuccessful";
                }
                else
                {
                    model.UserId = userId;
                    var result = await orderRepository.AddOrder(model, token);
                    
                    if (result != null)
                    {
                        response.Data = result;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Order Place is Unsuccessful";
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ResponceModel> GetAllOrders()
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserID").Value);

                var result = await orderRepository.GetAllOrders();

                if (result != null)
                {
                    response.Data = result;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Orders Retrive is Unsuccessful";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method is used to Retrive All orders
        /// </summary>
        /// <returns>List of Order</returns>
        [HttpGet("user-orders")]
        public async Task<ResponceModel> GetOrdersUserPlacesed()
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserID").Value);

                var result = await orderRepository.GetAllOrdersItemsUserPlacesed(userId);

                if (result != null)
                {
                    response.Data = result;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Order Retrive is Unsuccessful";
                }

                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpPost("PlaceOrder")]
        
        public async Task<ResponceModel> PlaceOrder(long OrderId)
        {
            try
            {
                string token = Request.Headers.Authorization.ToString();
                var result = await orderRepository.PlaceOrder(OrderId, token);

                if (result != null)
                {
                    response.Data = result;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Order Placed is Unsuccessful";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
