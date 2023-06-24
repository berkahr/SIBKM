using API.Models;

namespace API.Repositories.Interface
{
    public interface IAccountRoleRepository : IGeneralRepository<AccountRoles, int>
    {
        IEnumerable<string> GetRolesByEmail(string email);
    }
}