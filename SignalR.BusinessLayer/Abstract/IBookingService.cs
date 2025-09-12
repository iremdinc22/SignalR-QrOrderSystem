using SignalR.EntityLayer.Entities;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.BusinessLayer
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusApproved(int id);
        void TBookingStatusCancelled(int id);

        int TGetActiveBookingCount();
        int TGetPassiveBookingCount();
        int TGetTotalBookingCount();


    }
}