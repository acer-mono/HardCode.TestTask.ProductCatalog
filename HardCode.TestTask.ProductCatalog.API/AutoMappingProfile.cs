﻿using AutoMapper;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
using Attribute = HardCode.TestTask.ProductCatalog.Entities.Models.Attribute;

namespace HardCode.TestTask.ProductCatalog;

public sealed class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        AllowNullCollections = true;
        CreateMap<AttributeType, AttributeTypeDto>();
        CreateMap<Attribute, AttributeDto>()
            .ForPath(dest => dest.Type,
                opt =>
                    opt.MapFrom(src => src.Type.Name));
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryForCreationDto, Category>()
            .ForMember(d => d.Attributes,
                opt => opt.Ignore())
            .AfterMap((_, d) => d.Attributes = new List<Attribute>());
        CreateMap<ProductForCreationDto, Product>()
            .ForPath(dest => dest.Category,
                opt => opt.Ignore());
        CreateMap<ProductCategoryAttribute, ProductCategoryAttributeDto>()
            .ForPath(dest => dest.Name,
                opt =>
                    opt.MapFrom(src => src.Attribute.Name));
        CreateMap<Product, ProductDto>();
    }
}