using FakeStore.Database;
using FakeStore.Database.Models;
using FakeStoreApi.Repository;
using FakeStoreApi.Repository.FakeDb.Services;
using static FakeStoreApi.Repository.RepositoryPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.UseFakeStoreDatabase(new FakeDatabaseConfigurator()
{
    UsersConfiguration = new UsersConfigurator()
    {
        MaxDefaultUsers = 10,
        NullProbability = 0.2f
    },
    ProductsConfiguration = new ProductsConfigurator()
    {
        MaxPrice = 10000,
        MinPrice = 10,
        NullProbability = 0.2f
    },
    CategoriesConfiguration = new CategoriesConfigurator()
    {
        MaxCategories = 10,
        NullProbability = 0.2f
    }
});
// Define the databse to be used 
builder.Services.AddDatabase(ENVIROMENT.FAKEDB);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
