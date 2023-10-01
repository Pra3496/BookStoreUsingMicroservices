using Microsoft.EntityFrameworkCore;
using ProductManegementQuary.Model;
using ProductManegementQuary.Repository.Interface;
using ProductManegementUsingCQRS.Model;
using ProductManegementUsingCQRS.Repository.Context;

namespace ProductManegementQuary.Repository.Services
{
    public class ProductRepo : IProductRepo
    {
        private readonly ContextDBQuery contextDb;

        public ProductRepo(ContextDBQuery contextDb)
        {
            this.contextDb = contextDb;
        }


        public async Task<IEnumerable<QueryModel>> GetAllProduct()
        {
            try
            {
                List<QueryModel> model = new List<QueryModel>();
                var result = await contextDb.Products.ToListAsync();

                

                if(result.Count > 0)
                {
                    foreach(var item in result)
                    {
                        QueryModel queryModel = new()
                        {
                            ProductID = item.ProductID, 
                            ProductName = item.ProductName,
                            Qty= item.Qty,
                            Price= item.Price,
                            AddedBy= item.AddedBy,
                            AddedOn= item.AddedOn
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



        public async Task<QueryModel> GetProductById(long ProductId)
        {
            try
            {

                var result = await contextDb.Products.FirstOrDefaultAsync(x=> x.ProductID == ProductId);

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
