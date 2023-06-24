using API.Context;
using API.Model;
using API.Repositories.Interface;


namespace API.Repositories.Data
{
    public class BookRepository : GeneralRepositories<Book, int, MyContext>, IBookRepository
    {
        public BookRepository(MyContext context) : base(context) { }

    }
}
