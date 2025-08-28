using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    private readonly SignalRContext _context;

    public EfProductDal(SignalRContext context) : base(context)
    {
    }

    public List<Product> GetProductsWithCategories()
    {
        return _context.Products
            .Include(p => p.Category)
            .ToList();
    }
}