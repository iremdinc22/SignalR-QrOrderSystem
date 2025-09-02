using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    public void TAdd(Order entity)
    {
        _orderDal.Add(entity);
    }

    public void TUpdate(Order entity)
    {
        _orderDal.Update(entity);
    }

    public void TDelete(Order entity)
    {
        _orderDal.Delete(entity);
    }

    public Order TGetById(int id)
    {
        return _orderDal.GetById(id);
    }

    public List<Order> TGetAll()
    {
        return _orderDal.GetAll();
    }

    public int TTotalOrderCount()
    {
        return _orderDal.TotalOrderCount();
    }

    public int TActiveOrderCount()
    {
        return _orderDal.ActiveOrderCount();
    }
    
    public decimal TLastOrderPrice()
    {
        return _orderDal.LastOrderPrice();
    }
    

}