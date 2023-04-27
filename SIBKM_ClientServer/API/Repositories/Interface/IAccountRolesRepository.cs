using API.Models;

namespace API.Repositories.Interface
{
    public interface IAccountRolesRepository
    {
        IEnumerable<AccountRoles> GetAll();
        AccountRoles? GetById(int id);
        int Insert(AccountRoles accountRoles);
        int Update(AccountRoles accountRoles);
        int Delete(int id);
    }
}
