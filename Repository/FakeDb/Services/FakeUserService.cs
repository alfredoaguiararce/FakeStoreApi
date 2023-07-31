using FakeStore.Database.Models;
using FakeStore.Database.Statics;
using FakeStoreApi.Repository.FakeDb.Abstractions;

namespace FakeStoreApi.Repository.FakeDb.Services
{
    public class FakeUserService : UsersBase
    {
        private readonly IFakeStoreDatabase fakeDatabase;
        private static List<FakeUser>? fakeUsers = null;
        public FakeUserService(IFakeStoreDatabase fakeDb)
        {
            fakeDatabase = fakeDb;
        }


        public override void ChangeUserName(int UserId, string NewUserName)
        {
            List<FakeUser> users = GetAppGeneratedUsers();
            FakeUser? user = users.FirstOrDefault(user => user.UserId == UserId);
            if (user is null) throw new NotImplementedException();
            user.UserName = NewUserName;
            fakeDatabase.UpdateUsers(users);
        }

        public override void CreateUser(string FirstName, string LastName, string UserName, string Email, string Password)
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

        public override void CreateUserAdmin(string FirstName, string LastName, string UserName, string Email, string Password)
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

        public override FakeUser? GetUser(int UserId)
        {
            return GetAppGeneratedUsers()
                   .FirstOrDefault(user => user.UserId == UserId);
        }

        public override List<FakeUser> GetUsers()
        {
            return GetAppGeneratedUsers();
        }

        private int GetNextId()
        {
            List<FakeUser> users = GetAppGeneratedUsers();
            return users.Count() + 1;
        }

        private List<FakeUser> GetAppGeneratedUsers()
        {
            if (fakeUsers is null)
            {
                fakeUsers = new List<FakeUser>();
                fakeUsers = fakeDatabase.GetUsers();
            }
            return fakeUsers;
        }
    }

}
