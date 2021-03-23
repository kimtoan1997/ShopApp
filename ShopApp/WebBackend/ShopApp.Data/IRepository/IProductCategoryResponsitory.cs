using ShopApp.Data.Entities;
using ShopApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.IRepository
{
    public interface IProductCategoryResponsitory : IReponsitory<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}
