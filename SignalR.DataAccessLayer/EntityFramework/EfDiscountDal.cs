using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
{
    public EfDiscountDal(SignalRContext context) : base(context)
    {

    }

    public void ChangeStatusToFalse(int id)
    {
        using var context = new SignalRContext();
        var value = context.Discounts.Find(id);
        value.Status = false;
        context.SaveChanges();
    }

    public void ChangeStatusToTrue(int id)
    {
        using var context = new SignalRContext();
        var value = context.Discounts.Find(id);
        value.Status = true;
        context.SaveChanges();
    }

    public List<Discount> GetActiveDiscounts()
    {
        using var context = new SignalRContext();

        return context.Discounts
                      .AsNoTracking()       // EF tracking kapalı, performans için
                      .Where(d => d.Status) // sadece Status = true olanları getirir
                      .ToList();
    }



}