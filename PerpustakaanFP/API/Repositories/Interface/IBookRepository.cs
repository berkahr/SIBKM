using API.Model;


namespace API.Repositories.Interface
{
    public interface IBookRepository : IGeneralRepository<Book, int>
    {
        IEnumerable<Book> GetByName(string name);
    }
}
