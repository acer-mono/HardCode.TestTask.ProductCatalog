using Microsoft.AspNetCore.Mvc;

namespace HardCode.TestTask.ProductCatalog.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        throw new NotImplementedException();
    }
    
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