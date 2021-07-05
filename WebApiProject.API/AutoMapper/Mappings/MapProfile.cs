using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Core.Dtos;
using WebApiProject.Core.Entities;

namespace WebApiProject.API.AutoMapper.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
