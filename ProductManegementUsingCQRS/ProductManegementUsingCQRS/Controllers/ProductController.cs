using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManegementUsingCQRS.Model;
using ProductManegementUsingCQRS.Repository.Context;
using ProductManegementUsingCQRS.Repository.Interface;

namespace ProductManegementUsingCQRS.Controllers
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
        /// The Method is Used to Register the Product
        /// </summary>
        /// <param name="model">It has all parameter needed to add product</param>
        /// <returns>Responce with object of product detail</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("Product")]
        public async Task<ResponseModel> AddProducts(CommandModel model)
        {
            try
            {
                ProductEntity result = await productRepo.AddProducts(model);
                ResponseModel responseModel = new ResponseModel();
                if (result != null)
                {
                    responseModel.IsSuccess = true;
                    responseModel.Data = result;
                    responseModel.Message = "Adding Product is Successful";

                }
                return responseModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// This Method is Used to Update Product
        /// </summary>
        /// <param name="Product_ID">It used to verify the Product</param>
        /// <param name="model">It has Parameter that requred to Update</param>
        /// <returns>Responce with boolean value of product Update or not</returns>
        /// <exception cref="Exception"></exception>
        [HttpPut]
        [Route("Product")]
        public async Task<ResponseModel> UpdateProductAsync(int Product_ID, CommandModel model)
        {
            try
            {
                var product = await productRepo.UpdateProduct(Product_ID, model);
                ResponseModel responseModel = new ResponseModel();
                if (product != null)
                {
                    responseModel.IsSuccess = true;
                    responseModel.Data = product;
                    responseModel.Message = "Update Product is Successful";

                }
                return responseModel;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// This Method is Used to Remove the Product
        /// </summary>
        /// <param name="ProductID">It is Used to Verify the Product</param>
        /// <returns>Responce with boolean value of product Update or not</returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete]
        [Route("Product")]
        public async Task<ResponseModel> DeleteProduct(int ProductID)
        {
            try
            {
                var product = await productRepo.DeleteProduct(ProductID);
                ResponseModel responseModel = new ResponseModel();
                if (product != false)
                {
                    responseModel.IsSuccess = true;
                    responseModel.Message = "Update Product is Successful";
                    responseModel.Data = product;

                }
                return responseModel;
               
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }


        /// <summary>
        /// This method is used to Retrive All Products
        /// </summary>
        /// <returns>Responce with List of Products</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("Products")]
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
            catch (Exception ex)
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
        [Route("Product")]
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
