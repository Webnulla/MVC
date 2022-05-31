namespace WebCatalog.Domain.Entity;

public class Catalog<T>
{
    public List<T> ProductsList { get; set; } = new();

}