using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly MyContext _context;
        public AccountsRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<Accounts> GetAll()
        {
            return _context.Set<Accounts>().ToList();
        }
        public Accounts? GetById(string employee_nik)
        {
            return _context.Set<Accounts>().Find(employee_nik);
        }
        public int Insert(Accounts accounts)
        {
            _context.Set<Accounts>().Add(accounts);
            return _context.SaveChanges();
        }
        public int Update(Accounts accounts)
        {
            _context.Set<Accounts>().Update(accounts);
            return _context.SaveChanges();
        }
        public int Delete(string employee_nik)
        {
            var accounts = GetById(employee_nik);
            if (accounts == null)
                return 0;
            _context.Set<Accounts>().Remove(accounts);
            return _context.SaveChanges();
        }
    }
}