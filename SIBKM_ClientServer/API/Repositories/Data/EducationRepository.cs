using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class EducationRepository : IEducationsRepository
    {
        private readonly MyContext _context;
        public EducationRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<Educations> GetAll()
        {
            return _context.Set<Educations>().ToList();
        }
        public Educations? GetById(int id)
        {
            return _context.Set<Educations>().Find(id);
        }
        public int Insert(Educations educations)
        {
            _context.Set<Educations>().Add(educations);
            return _context.SaveChanges();
        }
        public int Update(Educations educations)
        {
            _context.Set<Educations>().Update(educations);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var educations = GetById(id);
            if (educations == null)
                return 0;
            _context.Set<Educations>().Remove(educations);
            return _context.SaveChanges();
        }
    }
}