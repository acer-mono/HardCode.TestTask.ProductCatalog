using HardCode.TestTask.ProductCatalog.Service.Contracts;
using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace HardCode.TestTask.ProductCatalog.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CategoryController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    /// <summary>
    /// Получение всех категорий
    /// </summary>
    /// <returns>Список категорий</returns>
    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetAll() => await _serviceManager.CategoryService.GetAllAsync();
    
    [HttpPost]
    public IActionResult Add()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult RemoveById(int id)
    {
        throw new NotImplementedException();
    }
}