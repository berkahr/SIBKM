using API.Models;
namespace API.Repositories.Interface
{
    public interface IUniversitiesRepository
    {
        IEnumerable<Universities> GetAll();
        Universities? GetById(int id);
        int Insert(Universities universities);
        int Update(Universities universities);
        int Delete(int id);
    }
}
