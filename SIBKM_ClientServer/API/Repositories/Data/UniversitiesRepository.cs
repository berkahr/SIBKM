using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class UniversitiesRepository : IUniversitiesRepository
    {
        private readonly MyContext _context;
        public UniversitiesRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<Universities> GetAll()
        {
            return _context.Set<Universities>().ToList();
        }
        public Universities? GetById(int  id)
        {
            return _context.Set<Universities>().Find(id);
        }
        public int Insert(Universities universities)
        {
            _context.Set<Universities>().Add(universities);
            return _context.SaveChanges();
        }
        public int Update(Universities universities)
        {
            _context.Set<Universities>().Update(universities);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var universities = GetById(id);
            if (universities == null)
                return 0;
            _context.Set<Universities>().Remove(universities);
            return _context.SaveChanges();
        }
    }
}
