using WebCatalog.Domain.Entity;

namespace WebCatalog.DAL.Repository.Interfaces;

public interface ICatalogRepository
{
    List<Products> GetAll();
    void Add(Products product);
    void Delete(int id);
}