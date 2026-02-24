using CP1.Architecture.ViewModels;
using CP1.Models;

namespace CP1.Architecture.Mappers;

public static class FoodbankMapper
{
    public static FoodbankViewModel ToViewModel(this FoodItem entity)
    {
        return new FoodbankViewModel
        {
            FoodItemId = entity.FoodItemId,
            Name = entity.Name,
            Category = entity.Category,
            Brand = entity.Brand,
            Description = entity.Description,
            Price = entity.Price,
            Unit = entity.Unit,
            QuantityInStock = entity.QuantityInStock,
            ExpirationDate = entity.ExpirationDate.HasValue
                ? entity.ExpirationDate.Value.ToDateTime(TimeOnly.MinValue)
                : null,
            IsPerishable = entity.IsPerishable,
            CaloriesPerServing = entity.CaloriesPerServing,
            Ingredients = entity.Ingredients,
            Barcode = entity.Barcode,
            Supplier = entity.Supplier,
            DateAdded = entity.DateAdded,
            IsActive = entity.IsActive,
            RoleId = entity.RoleId
        };
    }

    public static FoodItem ToEntity(this FoodbankViewModel model)
    {
        return new FoodItem
        {
            FoodItemId = model.FoodItemId,
            Name = model.Name,
            Category = model.Category,
            Brand = model.Brand,
            Description = model.Description,
            Price = model.Price,
            Unit = model.Unit,
            QuantityInStock = model.QuantityInStock,
            ExpirationDate = model.ExpirationDate.HasValue
                ? DateOnly.FromDateTime(model.ExpirationDate.Value)
                : null,
            IsPerishable = model.IsPerishable,
            CaloriesPerServing = model.CaloriesPerServing,
            Ingredients = model.Ingredients,
            Barcode = model.Barcode,
            Supplier = model.Supplier,
            DateAdded = model.DateAdded,
            IsActive = model.IsActive,
            RoleId = model.RoleId
        };
    }
}
