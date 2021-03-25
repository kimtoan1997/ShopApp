using ShopApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Interfaces
{
    public interface IProductCategoryService
    {
        ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm);
        void Update(ProductCategoryViewModel productCategoryVm);
        void Delete(int id);
        List<ProductCategoryViewModel> GetAll();
        List<ProductCategoryViewModel> GetAll(string keyword);
        List<ProductCategoryViewModel> GetByParentId(int parentId);
        ProductCategoryViewModel GetById(int id);
        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        List<ProductCategoryViewModel> GetHomeCategories(int top);
        void Save();
    }
}
