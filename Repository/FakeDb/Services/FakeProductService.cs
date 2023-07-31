using Bogus.DataSets;
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

        public override void EditProduct(int ProductId, int Category, string Name, string Description, float Price)
        {
            List<FakeProduct> products = GetAppGeneratedProducts();
            FakeProduct? product = products.FirstOrDefault(product => product.ProductId == ProductId);
            if (product is null) throw new NotImplementedException();
            product.CategoryId = Category;
            product.Name = Name;
            product.Description = Description;
            product.Price = Price;
            fakeDatabase.UpdateProducts(products);
        }

        public override FakeProduct? GetProduct(int ProductId)
        {
            return GetAppGeneratedProducts().FirstOrDefault(p => p.ProductId == ProductId);
        }

        public override List<FakeProduct> GetProducts()
        {
            return GetAppGeneratedProducts();
        }

        public override void CreateProduct(int UserCreatorId, int Category, string Name, string Description, float Price)
        {
            List<FakeProduct> products = GetAppGeneratedProducts();
            products.Add(new FakeProduct()
            {
                ProductId = GetNextId(),
                UserCreatorId = UserCreatorId,
                CategoryId = Category, 
                Name = Name, 
                Description = Description, 
                Price = Price,
                CreatedAt = DateTime.UtcNow,
                Archived = null
            });
            fakeDatabase.UpdateProducts(products);
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

        public override void ArchiveProduct(int ProductId)
        {
            List<FakeProduct> products = GetAppGeneratedProducts();
            FakeProduct? product = products.FirstOrDefault(product => product.ProductId == ProductId);
            if (product is null) throw new NotImplementedException();
            product.Archived = DateTime.UtcNow;
            fakeDatabase.UpdateProducts(products);
        }
    }
}
