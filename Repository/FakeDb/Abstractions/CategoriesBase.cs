using FakeStore.Database.Models;

namespace FakeStoreApi.Repository.FakeDb.Abstractions
{
    public abstract class CategoriesBase : ICategories
    {
        public abstract void ChangeCategoryName(int CategoryId, string NewName);
        public abstract void CreateCategory(string Name, int UserCreatorId);
        public abstract List<FakeCategory> GetCategories();
        public abstract FakeCategory? GetCategory(int CategoryId);
    }

    public interface ICategories
    {
        void ChangeCategoryName(int CategoryId, string NewName);
        void CreateCategory(string Name, int UserCreatorId);
        FakeCategory? GetCategory(int CategoryId);
        List<FakeCategory> GetCategories();
    }
}
