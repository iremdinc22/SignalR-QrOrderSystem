using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
    public EfCategoryDal(SignalRContext context) : base(context)
    {

    }

    public int CategoryCount()
    {
        using var context = new SignalRContext();
        return context.Categories.Count();
    }

    public int ActiveCategoryCount()
    {
        using var context = new SignalRContext();
        return context.Categories.Where(c => c.Status == true).Count();
    }

    public int PassiveCategoryCount()
    {
        using var context = new SignalRContext();
        return context.Categories.Where(c => c.Status == false).Count();
    }
    
}