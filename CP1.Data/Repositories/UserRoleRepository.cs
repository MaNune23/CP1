using CP1.Data.MSSQL;
using CP1.Models;
namespace CP1.Data.Repositories;

public interface IUserRoleRepository
{
    Task<bool> UpsertAsync(UserRole entity, bool isUpdating);
    Task<bool> CreateAsync(UserRole entity);
    Task<bool> DeleteAsync(UserRole entity);
    Task<IEnumerable<UserRole>> ReadAsync();
    Task<UserRole> FindAsync(int id);
    Task<bool> UpdateAsync(UserRole entity);
    Task<bool> UpdateManyAsync(IEnumerable<UserRole> entities);
    Task<bool> ExistsAsync(UserRole entity);
}

public class UserRoleRepository(ProductDbContext context) : RepositoryBase<UserRole>(context), IUserRoleRepository
{

}
