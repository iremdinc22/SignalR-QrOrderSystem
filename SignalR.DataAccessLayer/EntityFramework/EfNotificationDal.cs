using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationDal(SignalRContext context) : base(context)
    {

    }

    public List<Notification> GetAllNotificationByFalse()
    {
        using var context = new SignalRContext();
        return context.Notifications.Where(x => x.Status == false).ToList();

    }


    public void NotificationStatusChangeToTrue(int id)
    {
        using var context = new SignalRContext();
        var value = context.Notifications.Find(id);
        value.Status = true;
        context.SaveChanges();

    }

    public void NotificationStatusChangeToFalse(int id)
    {
        using var context = new SignalRContext();
        var value = context.Notifications.Find(id);
        value.Status = false;
        context.SaveChanges();

    }

    public int NotificationCountByStatusFalse()
    {
        using var context = new SignalRContext();
        return context.Notifications.Count(x => x.Status == false);

    }
}


