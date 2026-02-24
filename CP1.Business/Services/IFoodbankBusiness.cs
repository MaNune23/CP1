using CP1.Models;

namespace CP1.Business.Services;

public interface IFoodbankBusiness
{
    Task<IEnumerable<FoodItem>> GetFoodItemsAsync();
    Task<FoodItem?> GetFoodItemAsync(int id);
    Task<bool> CreateFoodItemAsync(FoodItem entity);
    Task<bool> UpdateFoodItemAsync(FoodItem entity);
    Task<bool> DeleteFoodItemAsync(int id);
}
