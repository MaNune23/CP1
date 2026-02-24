using CP1.Data.MSSQL;
using CP1.Models;
namespace CP1.Data.Repositories;

public interface IRoleRepository
{
    Task<bool> UpsertAsync(Role entity, bool isUpdating);
    Task<bool> CreateAsync(Role entity);
    Task<bool> DeleteAsync(Role entity);
    Task<IEnumerable<Role>> ReadAsync();
    Task<Role> FindAsync(int id);
    Task<bool> UpdateAsync(Role entity);
    Task<bool> UpdateManyAsync(IEnumerable<Role> entities);
    Task<bool> ExistsAsync(Role entity);
}

public class RoleRepository(ProductDbContext context) : RepositoryBase<Role>(context), IRoleRepository
{

}
