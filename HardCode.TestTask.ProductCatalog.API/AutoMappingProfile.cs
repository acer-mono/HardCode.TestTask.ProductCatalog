﻿using AutoMapper;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
using Attribute = HardCode.TestTask.ProductCatalog.Entities.Models.Attribute;

namespace HardCode.TestTask.ProductCatalog;

public sealed class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Attribute, AttributeDto>()
            .ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Name));
        CreateMap<Category, CategoryDto>();
    }
}