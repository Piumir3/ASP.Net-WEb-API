using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIDbContext _appDBContext;
        public ProductRepository(APIDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<product>> GetProduct()
        {
            return await _appDBContext.Products.ToListAsync();
        }
        public async Task<product> GetProductByID(int productId)
        {
            return await _appDBContext.Products.FindAsync(productId);
        }
        public async Task<product> InsertProduct(product objProduct)
        {
            _appDBContext.Products.Add(objProduct);
            await _appDBContext.SaveChangesAsync();
            return objProduct;
        }
        public async Task<product> UpdateProduct(product objProduct)
        {
            _appDBContext.Entry(objProduct).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objProduct;
        }
        public bool DeleteProduct(int productId)
        {
            bool result = false;
            var product = _appDBContext.Products.Find(productId);
            if (product != null)
            {
                _appDBContext.Entry(product).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
