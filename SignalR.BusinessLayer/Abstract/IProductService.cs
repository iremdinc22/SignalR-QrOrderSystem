using SignalR.EntityLayer.Entities;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.BusinessLayer
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
    }
}