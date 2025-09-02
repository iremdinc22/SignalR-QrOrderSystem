using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
{
    public EfMoneyCaseDal(SignalRContext context) : base(context)
    {

    }
    
    public decimal TotalMoneyCaseAmount()
    {
        using var context = new SignalRContext();
        return context.MoneyCases.Select(mc => mc.TotalAmount).FirstOrDefault();
    }
}