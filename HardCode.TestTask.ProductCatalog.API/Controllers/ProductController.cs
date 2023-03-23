using Microsoft.AspNetCore.Mvc;

namespace HardCode.TestTask.ProductCatalog.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
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
    
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        throw new NotImplementedException();
    }
}