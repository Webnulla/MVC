namespace WebCatalog.Domain.Entity;

public class Catalog
{
    private readonly object _obj = new();
    public List<Products> ProductsList { get; set; } = new();

    public void AddProduct(Products products)
    {
        lock (_obj)
        {
            ProductsList.Add(products);
        }
    }

    public void RemoveProduct(Products products)
    {
        lock (_obj)
        {
            ProductsList.Remove(products);
        }
    }

}