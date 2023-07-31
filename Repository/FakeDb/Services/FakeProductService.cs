using FakeStore.Database.Models;
using FakeStore.Database.Statics;
using FakeStoreApi.Repository.FakeDb.Abstractions;

namespace FakeStoreApi.Repository.FakeDb.Services
{
    public class FakeProductService : ProductBase
    {

        private readonly IFakeStoreDatabase fakeDatabase;
        private static List<FakeProduct>? fakeProducts = null;

        public FakeProductService(IFakeStoreDatabase fakeDatabase)
        {
            this.fakeDatabase = fakeDatabase;
        }

        public override void EditProduct(int ProductId, string Category, string Name, string Description, float Price)
        {
            throw new NotImplementedException();
        }

        public override FakeProduct? GetProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public override List<FakeProduct> GetProducts()
        {
            throw new NotImplementedException();
        }

        public override void CreateProduct(int ProductId, int UserCreatorId, string Category, string Name, string Description, float Price)
        {
            throw new NotImplementedException();
        }

        private int GetNextId()
        {
            List<FakeProduct> products = GetAppGeneratedProducts();
            return products.Count() + 1;
        }

        private List<FakeProduct> GetAppGeneratedProducts()
        {
            if (fakeProducts is null)
            {
                fakeProducts = new List<FakeProduct>();
                fakeProducts = fakeDatabase.GetProducts();
            }
            return fakeProducts;
        }
    }
}
