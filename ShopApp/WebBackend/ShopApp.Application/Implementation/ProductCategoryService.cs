using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShopApp.Application.Interfaces;
using ShopApp.Application.ViewModels;
using ShopApp.Data.Entities;
using ShopApp.Data.IRepository;
using ShopApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.Application.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryResponsitory _productCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ProductCategoryService(IProductCategoryResponsitory productCategoryResponsitory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productCategoryRepository = productCategoryResponsitory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
            return productCategoryVm;
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            List<ProductCategory> productCategories = _productCategoryRepository.FindAll().OrderBy(x => x.ParentId).ToList();
            return _mapper.Map<List<ProductCategoryViewModel>>(productCategories);
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {   List<ProductCategory> productCategories = new List<ProductCategory>();
            if (string.IsNullOrEmpty(keyword))
            {
                productCategories = _productCategoryRepository.FindAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
                                        .OrderBy(x => x.ParentId).ToList();
            }
            else
            { 
                productCategories = _productCategoryRepository.FindAll().OrderBy(x => x.ParentId).ToList();
            }
               
            return _mapper.Map<List<ProductCategoryViewModel>>(productCategories);
        }

        public ProductCategoryViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            throw new NotImplementedException();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}
