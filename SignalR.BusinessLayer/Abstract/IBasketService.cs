using SignalR.EntityLayer.Entities;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.BusinessLayer
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);
    }
}