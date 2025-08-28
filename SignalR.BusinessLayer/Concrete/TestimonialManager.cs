using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _testimonialDal;
    
    public TestimonialManager(ITestimonialDal testimonialDal)
    {
        _testimonialDal = testimonialDal;
    }
    public void TAdd(Testimonial entity)
    {
        _testimonialDal.Add(entity);
    }

    public void TUpdate(Testimonial entity)
    {
        _testimonialDal.Update(entity);
    }

    public void TDelete(Testimonial entity)
    {
        _testimonialDal.Delete(entity);
    }

    public Testimonial TGetById(int id)
    {
        return _testimonialDal.GetById(id);
    }

    public List<Testimonial> TGetAll()
    {
        return _testimonialDal.GetAll();
    }
}