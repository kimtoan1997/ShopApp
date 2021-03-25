using AutoMapper;
using ShopApp.Application.ViewModels;
using ShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
            .ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image,c.HomeFlag, c.SortOrder, 
                   c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription
            ));
        }
    }
}
