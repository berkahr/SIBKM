using API.Models;
namespace API.Repositories.Interface
{
    public interface IRolesRepository
    {
        IEnumerable<Roles> GetAll();
        Roles? GetById(int id);
        int Insert(Roles roles);
        int Update(Roles roles);
        int Delete(int id);
    }
}
