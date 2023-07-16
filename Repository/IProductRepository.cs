using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<product>> GetProduct();
        Task<product> GetProductByID(int productId);
        Task<product> InsertProduct(product objProduct);
        Task<product> UpdateProduct(product objProduct);
        bool DeleteProduct(int productId);
    }
}
