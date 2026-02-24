using CP1.Data.MSSQL;
using CP1.Models;
namespace CP1.Data.Repositories;

public interface IFoodItemRepository
{
    Task<bool> UpsertAsync(FoodItem entity, bool isUpdating);
    Task<bool> CreateAsync(FoodItem entity);
    Task<bool> DeleteAsync(FoodItem entity);
    Task<IEnumerable<FoodItem>> ReadAsync();
    Task<FoodItem> FindAsync(int id);
    Task<bool> UpdateAsync(FoodItem entity);
    Task<bool> UpdateManyAsync(IEnumerable<FoodItem> entities);
    Task<bool> ExistsAsync(FoodItem entity);
}

public class FoodItemRepository(ProductDbContext context) : RepositoryBase<FoodItem>(context), IFoodItemRepository
{

}
