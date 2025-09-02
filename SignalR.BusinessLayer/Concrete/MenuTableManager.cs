using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class MenuTableManager : IMenuTableService

{
    private readonly IMenuTableDal _menuTableDal;

    public MenuTableManager(IMenuTableDal menuTableDal)
    {
        _menuTableDal = menuTableDal;
    }

    public void TAdd(MenuTable entity)
    {
        _menuTableDal.Add(entity);
    }

    public void TDelete(MenuTable entity)
    {
        _menuTableDal.Delete(entity);
    }

    public MenuTable TGetById(int id)
    {
        return _menuTableDal.GetById(id);
    }
    public List<MenuTable> TGetAll()
    {
        return _menuTableDal.GetAll();
    }

    public void TUpdate(MenuTable entity)
    {
        _menuTableDal.Update(entity);
    }
    
    public int TMenuTableCount()
    {
        return _menuTableDal.MenuTableCount();
    }
}