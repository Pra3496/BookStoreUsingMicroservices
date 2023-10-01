using ProductManegementQuary.Model;

namespace ProductManegementQuary.Repository.Interface
{
    public interface IProductRepo
    {
        Task<IEnumerable<QueryModel>> GetAllProduct();

        Task<QueryModel> GetProductById(long ProductId);
    }
}
