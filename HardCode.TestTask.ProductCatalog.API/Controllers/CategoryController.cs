﻿using HardCode.TestTask.ProductCatalog.Service.Contracts;
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
    /// Получение доступных типов данных для атрибутов категорий (доступны: boolean, string, decimal, integer)
    /// </summary>
    [HttpGet("attribute/types")]
    public async Task<IEnumerable<AttributeTypeDto>> GetAllowedAttributeTypes() =>
        await _serviceManager.CategoryService.GetAllowedAttributeTypes();

    /// <summary>
    /// Получение всех категорий
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetAll() => await _serviceManager.CategoryService.GetAllAsync();
    
    /// <summary>
    /// Получение информации о категории по ее идентификатору
    /// </summary>
    /// <param name="id">Идентификатор категории</param>
    [HttpGet("{id:int}", Name = "CategoryById")]
    public async Task<CategoryDto> GetById(int id) => await _serviceManager.CategoryService.GetByIdAsync(id);
    
    /// <summary>
    /// Создание новой категории
    /// </summary>
    /// <param name="dto">Параметры для создания категории</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CategoryForCreationDto dto)
    {
        var createdCategory = await _serviceManager.CategoryService.AddAsync(dto);
        return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
    }
    
    /// <summary>
    /// Удаление существующей категории
    /// </summary>
    /// <param name="id">Идентификатор категории</param>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveById(int id)
    {
        await _serviceManager.CategoryService.RemoveAsync(id);
        return NoContent();
    }
}