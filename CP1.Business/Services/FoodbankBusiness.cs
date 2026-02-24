using CP1.Data.Repositories;
using CP1.Models;

namespace CP1.Business.Services;

public class FoodbankBusiness(IFoodItemRepository repository) : IFoodbankBusiness
{
    public async Task<IEnumerable<FoodItem>> GetFoodItemsAsync()
    {
        return await repository.ReadAsync();
    }

    public async Task<FoodItem?> GetFoodItemAsync(int id)
    {
        var entity = await repository.FindAsync(id);
        return entity;
    }

    public async Task<bool> CreateFoodItemAsync(FoodItem entity)
    {
        return await repository.CreateAsync(entity);
    }

    public async Task<bool> UpdateFoodItemAsync(FoodItem entity)
    {
        return await repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteFoodItemAsync(int id)
    {
        var entity = await repository.FindAsync(id);
        if (entity is null) return false;
        return await repository.DeleteAsync(entity);
    }
}
