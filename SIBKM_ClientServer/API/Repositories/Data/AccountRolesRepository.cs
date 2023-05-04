using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class AccountRolesRepository : GeneralRepository<AccountRoles, int, MyContext>, IAccountRolesRepository
    {
        public AccountRolesRepository(MyContext context) : base(context) { }
    }
}