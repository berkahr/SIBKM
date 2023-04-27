using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class RolesRepository : IRolesRepository
        {
            private readonly MyContext _context;
            public RolesRepository(MyContext context)
            {
                _context = context;
            }
            public IEnumerable<Roles> GetAll()
            {
                return _context.Set<Roles>().ToList();
            }
            public Roles? GetById(int id)
            {
                return _context.Set<Roles>().Find(id);
            }
            public int Insert(Roles roles)
            {
                _context.Set<Roles>().Add(roles);
                return _context.SaveChanges();
            }
            public int Update(Roles roles)
            {
                _context.Set<Roles>().Update(roles);
                return _context.SaveChanges();
            }
            public int Delete(int id)
            {
                var roles = GetById(id);
                if (roles == null)
                    return 0;
                _context.Set<Roles>().Remove(roles);
                return _context.SaveChanges();
            }
        }
}
