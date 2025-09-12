using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfBookingDal : GenericRepository<Booking>, IBookingDal
{
    public EfBookingDal(SignalRContext context) : base(context)
    {

    }

    public void BookingStatusApproved(int id)
    {
        using var context = new SignalRContext();
        var values = context.Bookings.Find(id);
        values.Description = "Rezervasyon Onaylandı";
        context.SaveChanges();

    }

    public void BookingStatusCancelled(int id)
    {
        using var context = new SignalRContext();
        var values = context.Bookings.Find(id);
        values.Description = "Rezervasyon İptal Edildi";
        context.SaveChanges();
    }


    public int GetActiveBookingCount()
    {
        using var context = new SignalRContext();
        return context.Bookings.Count(b => b.Description == "Rezervasyon Onaylandı");
    }

    public int GetPassiveBookingCount()
    {
        using var context = new SignalRContext();
        return context.Bookings.Count(b => b.Description == "Rezervasyon İptal Edildi");
    }
    
    public int GetTotalBookingCount()
    {
        using var context = new SignalRContext();
        return context.Bookings.Count();
    }

   
}
