using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Data;

namespace API.Repositories.Data
{
    public class EducationRepository : GeneralRepository<Educations, int, MyContext>, IEducationsRepository
    {
        public EducationRepository(MyContext context) : base(context) { }
    }
}
