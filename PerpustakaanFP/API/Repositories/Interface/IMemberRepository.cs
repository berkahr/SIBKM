﻿using API.Model;


namespace API.Repositories.Interface
{
    public interface IMemberRepository : IGeneralRepository<Member, int>
    {
        string GetFullNameByEmail(string email);
    }
}
