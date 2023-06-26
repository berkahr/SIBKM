using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Data;

namespace API.Repositories.Data
{
    public class RolesRepository : GeneralRepositories<Roles, int, MyContext>, IRolesRepository
    {
        public RolesRepository(MyContext context) : base(context) { }
    }

}
