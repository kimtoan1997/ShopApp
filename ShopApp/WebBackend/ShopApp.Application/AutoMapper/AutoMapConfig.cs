using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.AutoMapper
{
    public class AutoMapConfig
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelProfile());
                cfg.AddProfile(new ViewModelToDomainProfile());
            });
        }
    }
}
