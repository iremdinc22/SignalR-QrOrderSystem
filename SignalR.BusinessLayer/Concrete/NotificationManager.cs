using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;

    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public void TAdd(Notification entity)
    {
        _notificationDal.Add(entity);
    }

    public void TUpdate(Notification entity)
    {
        _notificationDal.Update(entity);
    }

    public void TDelete(Notification entity)
    {
        _notificationDal.Delete(entity);
    }

    public Notification TGetById(int id)
    {
        return _notificationDal.GetById(id);
    }

    public List<Notification> TGetAll()
    {
        return _notificationDal.GetAll();
    }

    public int TNotificationCountByStatusFalse()
    {
        return _notificationDal.NotificationCountByStatusFalse();
    }


    public List<Notification> TGetAllNotificationByFalse()
    {
        return _notificationDal.GetAllNotificationByFalse();
    }

    public void TNotificationStatusChangeToTrue(int id)
    {
         _notificationDal.NotificationStatusChangeToTrue(id);
    }

    public void TNotificationStatusChangeToFalse(int id)
    {
         _notificationDal.NotificationStatusChangeToFalse(id);
    }
}

