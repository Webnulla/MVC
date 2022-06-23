using System.Xml.Linq;
using WebCatalog.DAL.Repository.Interfaces;
using WebCatalog.Domain.Entity;

namespace WebCatalog.DAL.Repository;

public class CatalogRepository : ICatalogRepository
{
    private readonly ReaderWriterLockSlim _lock = new();
    private List<Products>? Products { get; set; }

    public List<Products> GetAll()
    {
        try
        {
            _lock.EnterWriteLock();
            return Products == null ? new List<Products>() : Products.Select(products => new Products()
            {
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
            }).ToList();
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }

    public void Add(Products product)
    {
        try
        {
            _lock.EnterWriteLock();
            if (Products == null)
            {
                Products = new List<Products>();
            }
            Products.Add(product);
        }
        finally
        {
            _lock.ExitWriteLock();
        }

    }

    public void Delete(int id)
    {
        try
        {
            _lock.EnterWriteLock();
            if (Products != null)
            {
                var product = Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    throw new Exception("Продукт не найден");
                }

                Products.Remove(product);
            }
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
}