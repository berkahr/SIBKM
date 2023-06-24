using API.Context;
using API.Model;
using API.Repositories.Interface;


namespace API.Repositories.Data
{
    public class OfficerRepository : GeneralRepositories<Officer, int, MyContext>, IOfficerRepository
    {
        public OfficerRepository(MyContext context) : base(context) { }

    }
}
