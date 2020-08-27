using Com.Solution.Core.Entities;
using Com.Solution.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Solution.Infraestructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storeContext.Product
                .Include(a => a.ProductType)
                .Include(a => a.ProductBrand)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storeContext.Product
                .Include(a => a.ProductBrand)
                .Include(a => a.ProductType)
                .ToListAsync(); 
        }
    }
}
