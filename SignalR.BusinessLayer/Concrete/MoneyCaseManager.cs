using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class MoneyCaseManager : IMoneyCaseService
{
    private readonly IMoneyCaseDal _moneyCaseDal;

    public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
    {
        _moneyCaseDal = moneyCaseDal;
    }
    public decimal TTotalMoneyCaseAmount()
    {
        return _moneyCaseDal.TotalMoneyCaseAmount();
    }

    public void TAdd(MoneyCase entity)
    {
        _moneyCaseDal.Add(entity);
    }           

    public void TUpdate(MoneyCase entity)
    {
        _moneyCaseDal.Update(entity);
    }

    public void TDelete(MoneyCase entity)
    {
        _moneyCaseDal.Delete(entity);
    }

    public MoneyCase TGetById(int id)
    {
        return _moneyCaseDal.GetById(id);
    }               

    public List<MoneyCase> TGetAll()
    {
        return _moneyCaseDal.GetAll();
    }



    

}