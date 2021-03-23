using ShopApp.Data.Entities;
using ShopApp.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.Data.EF.Repositories
{
    public class ProductCategoryRepository : EFReponsitory<ProductCategory, int>, IProductCategoryResponsitory
    {
        private readonly AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context) : base (context)
        {
            _context = context;
        }
        public List<ProductCategory> GetByAlias(string alias)
        {
            return _context.ProductCategories.Where(x => x.SeoAlias == alias).ToList();
        }
    }
}
