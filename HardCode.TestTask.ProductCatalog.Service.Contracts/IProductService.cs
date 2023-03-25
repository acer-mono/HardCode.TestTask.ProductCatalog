using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

namespace HardCode.TestTask.ProductCatalog.Service.Contracts;

public interface IProductService
{
    Task<ProductDto> AddAsync(ProductForCreationDto dto);
    Task<ProductDto> GetByIdAsync(int id);
}