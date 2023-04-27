using API.Models;
namespace API.Repositories.Interface
{
    public interface IProfilingsRepository
    {
        IEnumerable<Profilings> GetAll();
        Profilings? GetById(string employee_nik);
        int Insert(Profilings profilings);
        int Update(Profilings profilings);
        int Delete(string employee_nik);
    }
}
