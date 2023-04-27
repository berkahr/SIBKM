using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class AccountRolesRepository : IAccountRolesRepository
    {
        private readonly MyContext _context;
        public AccountRolesRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<AccountRoles> GetAll()
        {
            return _context.Set<AccountRoles>().ToList();
        }
        public AccountRoles? GetById(int id)
        {
            return _context.Set<AccountRoles>().Find(id);
        }
        public int Insert(AccountRoles accountRoles)
        {
            _context.Set<AccountRoles>().Add(accountRoles);
            return _context.SaveChanges();
        }
        public int Update(AccountRoles accountRoles)
        {
            _context.Set<AccountRoles>().Update(accountRoles);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var accountRoles = GetById(id);
            if (accountRoles == null)
                return 0;
            _context.Set<AccountRoles>().Remove(accountRoles);
            return _context.SaveChanges();
        }
    }
}