using AutoMapper;
using ShopApp.Application.ViewModels;
using ShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
