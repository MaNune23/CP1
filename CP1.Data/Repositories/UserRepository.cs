using CP1.Data.MSSQL;
using CP1.Models;
namespace CP1.Data.Repositories;

public interface IUserRepository
{
    Task<bool> UpsertAsync(User entity, bool isUpdating);
    Task<bool> CreateAsync(User entity);
    Task<bool> DeleteAsync(User entity);
    Task<IEnumerable<User>> ReadAsync();
    Task<User> FindAsync(int id);
    Task<bool> UpdateAsync(User entity);
    Task<bool> UpdateManyAsync(IEnumerable<User> entities);
    Task<bool> ExistsAsync(User entity);
}

public class UserRepository(ProductDbContext context) : RepositoryBase<User>(context), IUserRepository
{

}
