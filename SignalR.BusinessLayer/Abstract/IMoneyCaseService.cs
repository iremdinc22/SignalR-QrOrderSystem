using SignalR.EntityLayer.Entities;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.BusinessLayer
{
    public interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        decimal TTotalMoneyCaseAmount();
        
    }
}