using AutoMapper;
using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Entities.Exceptions;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using HardCode.TestTask.ProductCatalog.Service.Contracts;
using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
using Attribute = HardCode.TestTask.ProductCatalog.Entities.Models.Attribute;

namespace HardCode.TestTask.ProductCatalog.Service;

public sealed class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AttributeTypeDto>> GetAllowedAttributeTypes() =>
        _mapper.Map<IEnumerable<AttributeTypeDto>>(await _repositoryManager.CategoryRepository.GetAllowedAttributeTypesAsync());

    public async Task<IEnumerable<CategoryDto>> GetAllAsync() =>
        _mapper.Map<IEnumerable<CategoryDto>>(await _repositoryManager.CategoryRepository.GetAllAsync());

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new CategoryNotFoundException();
        }

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> AddAsync(CategoryForCreationDto dto)
    {
        var allowedAttributeTypes =
            await _repositoryManager.CategoryRepository.GetAllowedAttributeTypesAsync();
        var category = _mapper.Map<Category>(dto);

        foreach (var attribute in dto.Attributes)
        {
            var attributeType = allowedAttributeTypes.FirstOrDefault(type => type.Name == attribute.Type);
            if (attributeType == null)
            {
                throw new AttributeNotFoundException(attribute.Type);
            }

            category.Attributes.Add(new Attribute
            {
                Name = attribute.Name,
                Type = attributeType
            });
        }

        _repositoryManager.CategoryRepository.Add(category);
        await _repositoryManager.SaveAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task RemoveAsync(int id)
    {
        var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new CategoryNotFoundException();
        }
        
        _repositoryManager.CategoryRepository.Remove(category);
        await _repositoryManager.SaveAsync();
    }
}