namespace WebCatalog.Domain.Entity;

public class Catalog
{
    private readonly ReaderWriterLockSlim? _lock;
    public List<Products> ProductsList { get; set; } = new();

    public void AddItem(Products item)
    {
        try
        {
            _lock?.EnterWriteLock();
            ProductsList.Add(item);
        }
        finally
        {
            _lock?.ExitWriteLock();
        }
    }

    public bool RemoveItem(Products item)
    {
        try
        {
            _lock?.EnterWriteLock();
            return ProductsList.Remove(item);
        }
        finally
        {
            _lock?.ExitWriteLock();
        }
    }

}