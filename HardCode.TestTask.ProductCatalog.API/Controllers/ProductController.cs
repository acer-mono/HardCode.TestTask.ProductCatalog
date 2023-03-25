using HardCode.TestTask.ProductCatalog.Service.Contracts;
using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
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
    
    [HttpGet]
    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProductForCreationDto dto)
    {
        var createdProduct = await _serviceManager.ProductService.AddAsync(dto);
        return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
    }

    [HttpGet("{id:int}", Name = "ProductById")]
    public async Task<ProductDto> GetById(int id) =>
        await _serviceManager.ProductService.GetByIdAsync(id);
}