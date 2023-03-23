using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

namespace HardCode.TestTask.ProductCatalog.Service.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<AttributeTypeDto>> GetAllowedAttributeTypes();
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
    Task<CategoryDto> AddAsync(CategoryForCreationDto dto);
    Task RemoveAsync(int id);
}