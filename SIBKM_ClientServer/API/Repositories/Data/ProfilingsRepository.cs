using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class ProfilingsRepository : IProfilingsRepository
    {
        private readonly MyContext _context;
        public ProfilingsRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<Profilings> GetAll()
        {
            return _context.Set<Profilings>().ToList();
        }
        public Profilings? GetById(string employee_nik)
        {
            return _context.Set<Profilings>().Find(employee_nik);
        }
        public int Insert(Profilings profilings)
        {
            _context.Set<Profilings>().Add(profilings);
            return _context.SaveChanges();
        }
        public int Update(Profilings profilings)
        {
            _context.Set<Profilings>().Update(profilings);
            return _context.SaveChanges();
        }
        public int Delete(string employee_nik)
        {
            var profilings = GetById(employee_nik);
            if (profilings == null)
                return 0;
            _context.Set<Profilings>().Remove(profilings);
            return _context.SaveChanges();
        }
    }
}