using FakeStore.Database.Models;

namespace FakeStoreApi.Repository.FakeDb.Abstractions
{
    public abstract class ProductBase : IProducts
    {
        public abstract void EditProduct(int ProductId, string Category, string Name, string Description, float Price);
        public abstract FakeProduct? GetProduct(int ProductId);
        public abstract List<FakeProduct> GetProducts();
    }

    public interface IProducts
    {
        void EditProduct(int ProductId, string Category, string Name, string Description, float Price);
        FakeProduct? GetProduct(int ProductId);
        List<FakeProduct> GetProducts();
    }
}
