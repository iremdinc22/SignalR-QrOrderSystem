using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class MessageManager : IMessageService
{
    private readonly IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public void TAdd(Message entity)
    {
        _messageDal.Add(entity);
    }           

    public void TUpdate(Message entity)
    {
        _messageDal.Update(entity);
    }

    public void TDelete(Message entity)
    {
        _messageDal.Delete(entity);
    }

    public Message TGetById(int id)
    {
        return _messageDal.GetById(id);
    }               

    public List<Message> TGetAll()
    {
        return _messageDal.GetAll();
    }
}
