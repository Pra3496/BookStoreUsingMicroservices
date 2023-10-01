using Microsoft.EntityFrameworkCore;
using ProductManegementUsingCQRS.Model;
using ProductManegementUsingCQRS.Repository.Context;
using ProductManegementUsingCQRS.Repository.Interface;

namespace ProductManegementUsingCQRS.Repository.Services
{
    public class ProductRepo : IProductRepo
    {
        private readonly ContextDB context;

        public ProductRepo(ContextDB context)
        {
            this.context = context;
        }

   
        /// <summary>
        /// This Method is used to Add the Product to Database
        /// </summary>
        /// <param name="model">It is used to receive data as parameter</param>
        /// <returns>Product Object</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductEntity> AddProducts(CommandModel model)
        {
            ProductEntity productEntity = new ProductEntity();
            try
            {
                productEntity.ProductName = model.ProductName;
                productEntity.Qty = model.Qty;
                productEntity.Price = model.Price;
                productEntity.AddedBy = model.AddedBy;
                productEntity.AddedOn = model.AddedOn;

                if(productEntity != null)
                {
                    await context.Products.AddAsync(productEntity);

                    context.SaveChanges();

                    return  productEntity;
                }

                return null;
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// This Method is Used to Update Product from Database
        /// </summary>
        /// <param name="productId">It is used to verify the product</param>
        /// <param name="model">It is used to Updated parameter</param>
        /// <returns>Boolean Value Indicating operation done or not</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateProduct(long productId, CommandModel model)
        {
            try
            {
                var product = context.Products.FirstOrDefault(x=> x.ProductID == productId);

                product.ProductName = model.ProductName;
                product.Qty = model.Qty;
                product.Price = model.Price;
                product.AddedBy = model.AddedBy;

                if(product != null )
                {
                    context.Update(product);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This Method is Used to Remove product from database
        /// </summary>
        /// <param name="productId">It is use to verify the product</param>
        /// <returns>returns boolean value indicates operation done or not</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteProduct(long productId)
        {
            try
            {
                var product= context.Products.FirstOrDefault(x=> x.ProductID ==productId);

                if(product != null)
                {
                    context.Products.Remove(product);
                    await context.SaveChangesAsync();
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This Method is used to Retrive all product from Database
        /// </summary>
        /// <returns>List of all products available in database</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<QueryModel>> GetAllProduct()
        {
            try
            {
                List<QueryModel> model = new List<QueryModel>();

                var result = await context.Products.ToListAsync();

                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        QueryModel queryModel = new()
                        {
                            ProductID = item.ProductID,
                            ProductName = item.ProductName,
                            Qty = item.Qty,
                            Price = item.Price,
                            AddedBy = item.AddedBy,
                            AddedOn = item.AddedOn
                        };

                        model.Add(queryModel);
                    }
                    return model;
                }


                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// This method is used to retrive a product from database
        /// </summary>
        /// <param name="ProductId">it is used to verify the Product</param>
        /// <returns>Object of ProductEntity</returns>
        /// <exception cref="Exception"></exception>
        public async Task<QueryModel> GetProductById(long ProductId)
        {
            try
            {

                var result = await context.Products.FirstOrDefaultAsync(x => x.ProductID == ProductId);

                if (result != null)
                {

                    QueryModel queryModel = new()
                    {
                        ProductID = result.ProductID,
                        ProductName = result.ProductName,
                        Qty = result.Qty,
                        Price = result.Price,
                        AddedBy = result.AddedBy,
                        AddedOn = result.AddedOn
                    };

                    return queryModel;
                }


                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
