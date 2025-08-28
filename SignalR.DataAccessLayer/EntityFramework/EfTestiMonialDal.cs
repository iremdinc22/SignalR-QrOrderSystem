using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfTestiMonialDal : GenericRepository<Testimonial>,ITestimonialDal
{
    public EfTestiMonialDal(SignalRContext context) : base(context)
    {
        
    }
}