using API.Models;

namespace API.Repositories.Interface
{
    public interface IAccountsRepository
    {
        IEnumerable<Accounts> GetAll();
        Accounts? GetById(string employee_nik);
        int Insert(Accounts accounts);
        int Update(Accounts accounts);
        int Delete(string employee_nik);
    }
}
