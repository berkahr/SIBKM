using API.Models;

namespace API.Repositories.Interface
{
    public interface IEducationsRepository
    {
        IEnumerable<Educations> GetAll();
        Educations? GetById(int id);
        int Insert(Educations educations);
        int Update(Educations educations);
        int Delete(int id);
    }
}
