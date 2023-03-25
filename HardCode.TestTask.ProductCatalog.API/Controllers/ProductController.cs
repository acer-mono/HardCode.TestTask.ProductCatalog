using HardCode.TestTask.ProductCatalog.Service.Contracts;
using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
using HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace HardCode.TestTask.ProductCatalog.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    /// <summary>
    /// Поиск продуктов (используется POST, т.к. из-за большого числа атрибутов может быть переполнение строки запроса)
    /// </summary>
    /// <param name="parameters">Параметры поиска и фильтрации</param>
    /// <returns>Список продуктов, соответствующих параметрам запроса</returns>
    [HttpPost("all")]
    public async Task<IEnumerable<ProductDto>> GetAll([FromBody] ProductParameters parameters) =>
        await _serviceManager.ProductService.GetAll(parameters);
    
    /// <summary>
    /// Добавление нового продукта
    /// </summary>
    /// <param name="dto">Параметры</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProductForCreationDto dto)
    {
        var createdProduct = await _serviceManager.ProductService.AddAsync(dto);
        return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
    }

    /// <summary>
    /// Получение продукта по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Информация о продукте</returns>
    [HttpGet("{id:int}", Name = "ProductById")]
    public async Task<ProductDto> GetById(int id) =>
        await _serviceManager.ProductService.GetByIdAsync(id);
}