using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
using HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

namespace HardCode.TestTask.ProductCatalog.Service.Contracts;

public interface IProductService
{
    Task<ProductDto> AddAsync(ProductForCreationDto dto);
    Task<ProductDto> GetByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetAll(ProductParameters parameters);
}