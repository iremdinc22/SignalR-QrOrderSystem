using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class SocialMediaManager : ISocialMediaService
{
    private readonly ISocialMediaDal _socialMediaDal;
    
    public SocialMediaManager(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }
    public void TAdd(SocialMedia entity)
    {
        _socialMediaDal.Add(entity);
    }

    public void TUpdate(SocialMedia entity)
    {
        _socialMediaDal.Update(entity);
    }

    public void TDelete(SocialMedia entity)
    {
        _socialMediaDal.Delete(entity);
    }

    public SocialMedia TGetById(int id)
    {
        return _socialMediaDal.GetById(id);
    }

    public List<SocialMedia> TGetAll()
    {
        return _socialMediaDal.GetAll();
    }
}