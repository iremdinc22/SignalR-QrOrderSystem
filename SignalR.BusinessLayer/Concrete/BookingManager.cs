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
}