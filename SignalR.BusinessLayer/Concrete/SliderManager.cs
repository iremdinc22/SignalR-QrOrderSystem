using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class SliderManager : ISliderService
{
    private readonly ISliderDal _sliderDal;
    
    public SliderManager(ISliderDal sliderDal)
    {
        _sliderDal = sliderDal;
    }
    public void TAdd(Slider entity)
    {
        _sliderDal.Add(entity);
    }

    public void TUpdate(Slider entity)
    {
        _sliderDal.Update(entity);
    }

    public void TDelete(Slider entity)
    {
        _sliderDal.Delete(entity);
    }

    public Slider TGetById(int id)
    {
        return _sliderDal.GetById(id);
    }

    public List<Slider> TGetAll()
    {
        return _sliderDal.GetAll();
    }
}
