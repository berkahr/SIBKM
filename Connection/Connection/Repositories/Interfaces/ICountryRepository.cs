using Connection.Models;

namespace Connection.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        List<country> GetAll();
        country GetById(string Id);
        int Insert(country country);
        int Update(country country);
        int Delete(string Id);
    }
}
