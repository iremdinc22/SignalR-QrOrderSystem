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

    public int ProductCount()
    {
        using var context = new SignalRContext();
        return context.Products.Count();
    }

    public int ProductCountByCategoryNameHamburger()
    {
        using var context = new SignalRContext();
        return context.Products.Where(p => p.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
    }

    public int ProductCountByCategoryNameDrink()
    {
        using var context = new SignalRContext();
        return context.Products.Where(p => p.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
    }

    public decimal ProductPriceAvg()
    {
        using var context = new SignalRContext();
        return context.Products.Average(p => p.Price);
    }

    public string ProductNameByMaxPrice()
    {
        using var context = new SignalRContext();
        return context.Products.Where(p => p.Price == context.Products.Max(x => x.Price)).Select(y => y.ProductName).FirstOrDefault() ?? "";
    }

    public string ProductNameByMinPrice()
    {
        using var context = new SignalRContext();
        return context.Products.Where(p => p.Price == context.Products.Min(x => x.Price)).Select(y => y.ProductName).FirstOrDefault() ?? "";
    }
    
    public decimal ProductAvgPriceByHamburger()
    {
        using var context = new SignalRContext();
        return context.Products.Where(p => p.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(p => p.Price);
    }

}