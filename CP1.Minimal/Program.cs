using CP1.Architecture;
using CP1.Architecture.Mappers;
using CP1.Architecture.Providers;
using CP1.Architecture.ViewModels;
using CP1.Business.Services;
using CP1.Data.MSSQL;
using CP1.Data.Repositories;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection (DB + Repositories + Business)
builder.Services.AddScoped<ProductDbContext>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<IFoodbankBusiness, FoodbankBusiness>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET (Minimal API) - List all food items
app.MapGet("/foodbank", async (IFoodbankBusiness business) =>
{
    var items = await business.GetFoodItemsAsync();
    var viewModels = items.Select(x => x.ToViewModel()).ToList();

    return Results.Ok(new ComplexObject
    {
        Success = true,
        Entities = viewModels.Select(vm => (object)JsonProvider.Serialize(vm)).ToList()
    });
});

// GET (Minimal API) - Get by id
app.MapGet("/foodbank/{id:int}", async (int id, IFoodbankBusiness business) =>
{
    var entity = await business.GetFoodItemAsync(id);
    if (entity is null)
    {
        return Results.NotFound(new ComplexObject
        {
            Success = false,
            Errors = new List<string> { "Food item not found." },
            Entities = new List<object>()
        });
    }

    var vm = entity.ToViewModel();
    return Results.Ok(new ComplexObject
    {
        Success = true,
        Entities = new List<object> { JsonProvider.Serialize(vm) }
    });
});

app.Run();
