using FakeStore.Database.Models;
using FakeStore.Database.Statics;
using FakeStoreApi.Repository.FakeDb.Abstractions;

namespace FakeStoreApi.Repository.FakeDb.Services
{
    public class FakeProductService : ProductBase
    {

        private readonly IFakeStoreDatabase fakeDatabase;
        private static List<FakeProduct>? fakeProducts = null;
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
    }
}
