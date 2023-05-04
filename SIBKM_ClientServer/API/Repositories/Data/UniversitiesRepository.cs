using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class UniversitiesRepository : GeneralRepository<Universities, int, MyContext>, IUniversitiesRepository
    {
        public UniversitiesRepository(MyContext context) : base(context) { }
    }
}