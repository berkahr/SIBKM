using API.Models;
using API.ViewModels;

namespace API.Repositories.Interface
{
    public interface IAccountsRepository : IGeneralRepository<Accounts, string>
    {
        int Register(RegisterAccountVM registerAccountVM);
        bool Login(LoginVM loginVm);
    }
}