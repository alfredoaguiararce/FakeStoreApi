using FakeStoreApi.Repository.FakeDb.Abstractions;
using FakeStoreApi.Repository.FakeDb.Services;

namespace FakeStoreApi.Repository
{
    public static class RepositoryPattern
    {
        public static void AddDatabase(this IServiceCollection services, ENVIROMENT EnviromentType)
        {
            if(EnviromentType is ENVIROMENT.FAKEDB)
            {
                services.AddScoped<IUsers, FakeUserService>();
                services.AddScoped<ICategories, FakeCategoryService>();
            }

            if(EnviromentType is ENVIROMENT.ENTITYFRAMEWORK)
            {
                throw new NotImplementedException();
            }
        }

        public enum ENVIROMENT
        {
            FAKEDB = 1,
            ENTITYFRAMEWORK = 2
        }
    }
}
