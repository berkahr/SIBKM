﻿using API.Models;
using API.ViewModels;

namespace API.Repositories.Interface
{
    public interface IAccountsRepository : IGeneralRepository<Accounts, string>
    {
        int Register(RegisterVM registerVM);
        bool Login(LoginVM loginVm);
    }
}