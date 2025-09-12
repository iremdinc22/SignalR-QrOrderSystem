using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;

    public BookingManager(IBookingDal bookingDal)
    {
        _bookingDal = bookingDal;
    }
    public void TAdd(Booking entity)
    {
        _bookingDal.Add(entity);
    }

    public void TUpdate(Booking entity)
    {
        _bookingDal.Update(entity);
    }

    public void TDelete(Booking entity)
    {
        _bookingDal.Delete(entity);
    }

    public Booking TGetById(int id)
    {
        return _bookingDal.GetById(id);
    }

    public List<Booking> TGetAll()
    {
        return _bookingDal.GetAll();
    }

    public void TBookingStatusApproved(int id)
    {
        _bookingDal.BookingStatusApproved(id);
    }

    public void TBookingStatusCancelled(int id)
    {
        _bookingDal.BookingStatusCancelled(id);
    }

    public int TGetActiveBookingCount()
    {
       return _bookingDal.GetActiveBookingCount();
    }

    public int TGetPassiveBookingCount()
    {
       return _bookingDal.GetPassiveBookingCount();
    }

    public int TGetTotalBookingCount()
    {
       return _bookingDal.GetTotalBookingCount();
    }
}