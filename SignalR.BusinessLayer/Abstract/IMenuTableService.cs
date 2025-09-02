using SignalR.EntityLayer.Entities;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.BusinessLayer
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        int TMenuTableCount();
        
    }
}