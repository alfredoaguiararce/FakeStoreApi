using FakeStore.Database.Models;
using FakeStore.Database.Statics;

namespace FakeStoreApi.Services
{
    public class UserService : IUsers
    {
        private readonly IFakeStoreDatabase _FakeDb;
        private static List<FakeUser>? _FakeUsers = null;
        public UserService(IFakeStoreDatabase fakeDb)
        {
            _FakeDb = fakeDb;
        }

        public void CreateUser(string FirstName, string LastName, string UserName, string Email, string Password)
        {
            List<FakeUser> users = GetAppGeneratedUsers();
            users.Add(new FakeUser()
            {
                UserId = GetNextId(),
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
                Password = Password,
                CreatedAt = DateTime.UtcNow,
                Archived = null,
                IsAdmin = false,
            });
        }

        public void CreateUserAdmin(string FirstName, string LastName, string UserName, string Email, string Password)
        {
            List<FakeUser> users = GetAppGeneratedUsers();
            users.Add(new FakeUser()
            {
                UserId = GetNextId(),
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
                Password = Password,
                CreatedAt = DateTime.UtcNow,
                Archived = null,
                IsAdmin = true,
            });
        }
        public List<FakeUser> GetUsers()
        {
            return GetAppGeneratedUsers();
        }
        public FakeUser? GetUser(int UserId)
        {
            return GetAppGeneratedUsers().FirstOrDefault(user => user.UserId == UserId);
        }

        public void ChangeUserName(int UserId, string NewUserName)
        {
            List<FakeUser> users = GetAppGeneratedUsers();
            FakeUser? user = users.FirstOrDefault(user => user.UserId == UserId);
            if (user is null) throw new NotImplementedException();
            user.UserName = NewUserName;
            _FakeDb.UpdateUsers(users);
        }
        private List<FakeUser> GetAppGeneratedUsers()
        {
            if (_FakeUsers is null)
            {
                _FakeUsers = new List<FakeUser>();
                _FakeUsers = _FakeDb.GetUsers();
            }
            return _FakeUsers;
        }

        private int GetNextId()
        {
            List<FakeUser> users = GetAppGeneratedUsers();
            return users.Count() + 1;
        }
    }

    public interface IUsers
    {
        void ChangeUserName(int UserId, string NewUserName);
        void CreateUser(string FirstName, string LastName, string UserName, string Email, string Password);
        void CreateUserAdmin(string FirstName, string LastName, string UserName, string Email, string Password);
        FakeUser? GetUser(int UserId);
        List<FakeUser> GetUsers();
    }
}
