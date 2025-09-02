using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class OrderDetailManager : IOrderDetailService
{
    private readonly IOrderDetailDal _orderDetailDal;
    
    public OrderDetailManager(IOrderDetailDal orderDetailDal)
    {
        _orderDetailDal = orderDetailDal;
    }

    public void TAdd(OrderDetail entity)
    {
        _orderDetailDal.Add(entity);
    }           

    public void TUpdate(OrderDetail entity)
    {
        _orderDetailDal.Update(entity);
    }

    public void TDelete(OrderDetail entity)
    {
        _orderDetailDal.Delete(entity);
    }

    public OrderDetail TGetById(int id)
    {
        return _orderDetailDal.GetById(id);
    }               

    public List<OrderDetail> TGetAll()
    {
        return _orderDetailDal.GetAll();
    }

    }