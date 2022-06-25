using System.Xml.Linq;
using WebCatalog.DAL.Repository.Interfaces;
using WebCatalog.Domain.Entity;

namespace WebCatalog.DAL.Repository;

public class CatalogRepository : ICatalogRepository
{
    private List<Products>? Products { get; set; }

    public List<Products> GetAll()
    {
        return Products == null ? new List<Products>() : Products.Select(products => new Products()
        {
            Id = products.Id,
            Name = products.Name,
            Description = products.Description,
            Price = products.Price,
        }).ToList();
    }

    public void Add(Products product)
    {
        if (Products == null)
        {
            Products = new List<Products>();
        }
        Products.Add(product);
    }

    public void Delete(int id)
    {
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
}