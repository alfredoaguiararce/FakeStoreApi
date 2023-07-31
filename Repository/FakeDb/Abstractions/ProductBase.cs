using FakeStore.Database.Models;

namespace FakeStoreApi.Repository.FakeDb.Abstractions
{
    public abstract class ProductBase : IProducts
    {
        public abstract void ArchiveProduct(int ProductId);
        public abstract void CreateProduct(int UserCreatorId, int Category, string Name, string Description, float Price);
        public abstract void EditProduct(int ProductId, int Category, string Name, string Description, float Price);
        public abstract FakeProduct? GetProduct(int ProductId);
        public abstract List<FakeProduct> GetProducts();
    }

    public interface IProducts
    {
        void CreateProduct(int UserCreatorId, int Category, string Name, string Description, float Price);
        void EditProduct(int ProductId, int Category, string Name, string Description, float Price);
        FakeProduct? GetProduct(int ProductId);
        List<FakeProduct> GetProducts();
        void ArchiveProduct(int ProductId);
    }
}
