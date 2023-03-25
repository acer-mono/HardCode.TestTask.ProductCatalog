namespace HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

public sealed record CategoryAttributeParameters
{
    public int Id { get; set; }
    public object? From { get; set; }
    public object? To { get; set; }
    public object? Eq { get; set; }
    public object? Contains { get; set; }
}