using FakeStore.Database.Models;
using FakeStore.Database.Statics;
using FakeStoreApi.Repository.FakeDb.Abstractions;

namespace FakeStoreApi.Repository.FakeDb.Services
{
    public class FakeCategoryService : CategoriesBase
    {
        private readonly IFakeStoreDatabase _FakeDb;
        private static List<FakeCategory>? _FakeCategories = null;

        public FakeCategoryService(IFakeStoreDatabase fakeDb)
        {
            _FakeDb = fakeDb;
        }

        public override void ChangeCategoryName(int CategoryId, string NewName)
        {
            List<FakeCategory> Categories = GetAppGeneratedCategories();
            FakeCategory? Category = Categories.FirstOrDefault(category => category.CategoryId == CategoryId);
            if (Category is null) throw new NotImplementedException();
            Category.Name = NewName;
            _FakeDb.UpdateCategories(Categories);
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
            if (_FakeCategories is null)
            {
                _FakeCategories = new List<FakeCategory>();
                _FakeCategories = _FakeDb.GetCategories();
            }
            return _FakeCategories;
        }
    }
}
