using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
{
    public EfMenuTableDal(SignalRContext context) : base(context)
    {

    }

    public void ChangeMenuTableStatus(int id, bool status)
    {
        using var context = new SignalRContext();
        var menuTable = context.MenuTables.Find(id);
        if (menuTable != null)
        {
            menuTable.Status = status;
            context.SaveChanges();
        }
    }

    public int MenuTableCount()
    {
        using var context = new SignalRContext();
        return context.MenuTables.Count();
    }
    
    
}