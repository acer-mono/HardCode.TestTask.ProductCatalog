using AutoMapper;
using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Entities.Exceptions;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using HardCode.TestTask.ProductCatalog.Service.Contracts;
using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
using HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

namespace HardCode.TestTask.ProductCatalog.Service;

public sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<ProductDto> AddAsync(ProductForCreationDto dto)
    {
        var category = await _repositoryManager.CategoryRepository.GetByIdAsync(dto.CategoryId);
        if (category == null)
        {
            throw new CategoryNotFoundException();
        }

        if (dto.Attributes.Any(attribute =>
                !category.Attributes.Select(categoryAttribute => categoryAttribute.Id).Contains(attribute.Id)))
        {
            throw new CategoryAttributeNotFoundException();
        }

        var product = _mapper.Map<Product>(dto);
        _repositoryManager.ProductRepository.Add(product);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new ProductNotFoundException();
        }

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAll(ProductParameters parameters)
    {
        var products = await _repositoryManager.ProductRepository.GetAll(parameters);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}