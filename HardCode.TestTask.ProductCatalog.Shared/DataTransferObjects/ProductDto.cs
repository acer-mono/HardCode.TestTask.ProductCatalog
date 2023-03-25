namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения продукта
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
/// <param name="Description">Описание</param>
/// <param name="Price">Цена</param>
/// <param name="Image">Изображение</param>
/// <param name="CategoryId">Идентификатор категории</param>
/// <param name="Attributes">Дополнительные поля категории товара</param>
public sealed record ProductDto(int Id,
    string Name,
    string? Description,
    decimal Price,
    string? Image,
    int CategoryId, 
    IEnumerable<ProductCategoryAttributeDto> Attributes);