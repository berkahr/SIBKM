using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class ProfilingsRepository : GeneralRepository<Profilings, string, MyContext>, IProfilingsRepository
    {
        public ProfilingsRepository(MyContext context) : base(context) { }
    }
}
