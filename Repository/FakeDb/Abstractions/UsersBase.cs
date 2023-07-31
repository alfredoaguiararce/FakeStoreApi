using FakeStore.Database.Models;

namespace FakeStoreApi.Repository.FakeDb.Abstractions
{
    public abstract class UsersBase : IUsers
    {
        public abstract void ArchiveUser(int UserId);
        public abstract void ChangeUserName(int UserId, string NewUserName);
        public abstract void CreateUser(string FirstName, string LastName, string UserName, string Email, string Password);
        public abstract void CreateUserAdmin(string FirstName, string LastName, string UserName, string Email, string Password);
        public abstract FakeUser? GetUser(int UserId);
        public abstract List<FakeUser> GetUsers();
    }

    public interface IUsers
    {
        void ChangeUserName(int UserId, string NewUserName);
        void CreateUser(string FirstName, string LastName, string UserName, string Email, string Password);
        void CreateUserAdmin(string FirstName, string LastName, string UserName, string Email, string Password);
        FakeUser? GetUser(int UserId);
        List<FakeUser> GetUsers();
        void ArchiveUser(int UserId);
    }
}
