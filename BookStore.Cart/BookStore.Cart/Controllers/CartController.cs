using BookStore.Cart.Model;
using BookStore.Cart.Repository;
using BookStore.Cart.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Cart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo cartRepo;

        public CartController(ICartRepo cartRepo)
        {
              this.cartRepo = cartRepo;
        }



        [HttpPost]
        public async Task<ResponseModel> AddToCart(CartModel model)
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserID").Value);

                model.UserId = userId;

                ResponseModel responseModel= new ResponseModel();
                CartEntity result = await this.cartRepo.AddToCart(model);

                if (result != null)
                {
                    responseModel.IsSuccess = true;
                    responseModel.Message = "Add To Cart Successful";
                    responseModel.Data = result;
                }
                return responseModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCart()
        {

            try
            {
                long userId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.cartRepo.GetAllCart(userId);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Retrival of Cart Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Retrival of Cart Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> GetAllCartWhichOrder()
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.cartRepo.GetAllCartWhichOrder(userId);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Cart Ordered Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Cart Ordered Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteById(long CartId)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                bool result = await this.cartRepo.DeleteById(CartId);

                if (result != false)
                {
                    responseModel.IsSuccess = true;
                    responseModel.Message = "Delete Cart Successful";
                    
                }
                return responseModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
