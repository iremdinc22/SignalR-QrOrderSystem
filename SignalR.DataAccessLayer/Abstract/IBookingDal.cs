using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract;

public interface IBookingDal : IGenericDal<Booking>
{
    void BookingStatusApproved(int id);
    void BookingStatusCancelled(int id);
    int GetActiveBookingCount();
    int GetPassiveBookingCount();
    int GetTotalBookingCount();





}