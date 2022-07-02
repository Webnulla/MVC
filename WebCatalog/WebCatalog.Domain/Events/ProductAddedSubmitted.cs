using WebCatalog.Domain.Entity;

namespace WebCatalog.Domain.Events;

public class ProductAddedSubmitted : IDomainEvents
{
    public Products Product { get; }

    public ProductAddedSubmitted(Products product)
    {
        Product = product;
    }
}