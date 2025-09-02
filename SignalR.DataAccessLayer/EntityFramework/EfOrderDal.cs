using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfOrderDal : GenericRepository<Order>, IOrderDal
{
    public EfOrderDal(SignalRContext context) : base(context)
    {

    }

    public int TotalOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Count();
    }

    public int ActiveOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Count(o => o.Description == "Müşteri Masada");
    }
    
    public decimal LastOrderPrice()
    {
        using var context = new SignalRContext();
        return context.Orders.OrderByDescending(o => o.OrderID).Take(1).Select(o => o.TotalPrice).FirstOrDefault();
    }
}