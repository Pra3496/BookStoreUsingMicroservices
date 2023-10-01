using ProductManegementUsingCQRS.Model;
using ProductManegementUsingCQRS.Repository.Context;

namespace ProductManegementUsingCQRS.Repository.Interface
{
    public interface IProductRepo
    {

        Task<ProductEntity> AddProducts(CommandModel model);

        Task<bool> UpdateProduct(long productId, CommandModel model);

        Task<bool> DeleteProduct(long productId);


        Task<IEnumerable<QueryModel>> GetAllProduct();

        Task<QueryModel> GetProductById(long ProductId);
    }
}
