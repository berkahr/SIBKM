using API.Context;
using API.Model;
using API.Repositories.Interface;


namespace API.Repositories.Data
{
    public class MemberRepository : GeneralRepositories<Member, int, MyContext>, IMemberRepository
    {
        public MemberRepository(MyContext context) : base(context) { }

    }
}
