using FakeStore.Database.Models;
using FakeStore.Database.Statics;
using FakeStoreApi.Repository.FakeDb.Abstractions;

namespace FakeStoreApi.Repository.FakeDb.Services
{
    public class FakeCategoryService : CategoriesBase
    {
        private readonly IFakeStoreDatabase fakeDatabase;
        private static List<FakeCategory>? fakeCategories = null;

        public FakeCategoryService(IFakeStoreDatabase fakeDb)
        {
            fakeDatabase = fakeDb;
        }

        public override void ChangeCategoryName(int CategoryId, string NewName)
        {
            List<FakeCategory> Categories = GetAppGeneratedCategories();
            FakeCategory? Category = Categories.FirstOrDefault(category => category.CategoryId == CategoryId);
            if (Category is null) throw new NotImplementedException();
            Category.Name = NewName;
            fakeDatabase.UpdateCategories(Categories);
        }

        public override void CreateCategory(string Name, int UserCreatorId)
        {
            FakeCategory new_category = new FakeCategory()
            {
                Name = Name,
                CreatedAt = DateTime.UtcNow,
                Archived = null,
                UserCreatorId = UserCreatorId
            };
            GetAppGeneratedCategories().Add(new_category);
        }

        public override List<FakeCategory> GetCategories()
        {
            return GetAppGeneratedCategories();
        }

        public override FakeCategory? GetCategory(int CategoryId)
        {
            return GetAppGeneratedCategories()
                   .FirstOrDefault(category => category.CategoryId == CategoryId);
        }

        private int GetNextId()
        {
            List<FakeCategory> users = GetAppGeneratedCategories();
            return users.Count() + 1;
        }

        private List<FakeCategory> GetAppGeneratedCategories()
        {
            if (fakeCategories is null)
            {
                fakeCategories = new List<FakeCategory>();
                fakeCategories = fakeDatabase.GetCategories();
            }
            return fakeCategories;
        }
    }
}
