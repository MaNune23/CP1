using CP1.Business.Services;
using CP1.Data.MSSQL;
using CP1.Data.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Dependency Injection (DB + Repositories + Business)
builder.Services.AddScoped<ProductDbContext>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<IFoodbankBusiness, FoodbankBusiness>();


// Add services to the container.

builder.Services.AddControllers();
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