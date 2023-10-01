using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManegementQuary.Repository.Interface;


namespace ProductManegementQuary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productRepo;

        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        /// <summary>
        /// This method is used to Retrive All Products
        /// </summary>
        /// <returns>Responce with List of Products</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await productRepo.GetAllProduct();

                if (result != null)
                {
                    return Ok(new { success = true, message = "Products Retrive Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Products Retrive Unsuccessfully", data = result });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// This Method is Used to Retrive Product
        /// </summary>
        /// <param name="ProductID">It is required to verify Product</param>
        /// <returns>Object of Product</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        public async Task<IActionResult> GetProduct(long ProductID)
        {
            try
            {
                var result = await productRepo.GetProductById(ProductID);

                if (result != null)
                {
                    return Ok(new { success = true, message = "Products Retrive Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Products Retrive Unsuccessfully", data = result });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
