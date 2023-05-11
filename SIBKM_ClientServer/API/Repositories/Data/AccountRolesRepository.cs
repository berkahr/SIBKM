using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRoles, int, MyContext>, IAccountRoleRepository
    {
        public AccountRoleRepository(MyContext context) : base(context) { }
        public IEnumerable<string> GetRolesByEmail(string email)
        {
            var employeeNIK = _context.Employees.FirstOrDefault(e => e.email == email)!.nik;
            var accountRoles = _context.AccountRoles
                                       .Where(ar => ar.account_nik == employeeNIK)
                                       .Join(_context.Roles,
                                             ar => ar.id,
                                             r => r.id,
                                             (ar, r) => new { ar, r })
                                       .Select(role => role.r.name);

            return accountRoles;
        }
    }
}