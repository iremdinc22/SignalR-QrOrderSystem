using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BusinessLayer.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IFeatureDal _featureDal;
    
    public FeatureManager(IFeatureDal featureDal)
    {
        _featureDal = featureDal;
    }
    public void TAdd(Feature entity)
    {
        _featureDal.Add(entity);
    }

    public void TUpdate(Feature entity)
    {
        _featureDal.Update(entity);
    }

    public void TDelete(Feature entity)
    {
        _featureDal.Delete(entity);
    }

    public Feature TGetById(int id)
    {
        return _featureDal.GetById(id);
    }

    public List<Feature> TGetAll()
    {
        return _featureDal.GetAll();
    }
}