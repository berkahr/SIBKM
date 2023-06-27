﻿using API.Context;
using API.Handlers;
using API.Model;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data
{
    public class AccountRepository : GeneralRepositories<Accounts, string, MyContext>, IAccountsRepository
    {
        public AccountRepository(MyContext context) : base(context) { }
        public int Register(RegisterVM registerVM)
        {
            int result = 0;

            //insert to borrow table
            var borrow = new Borrow
            {
                OfficerId = registerVM.OfficerId,
                MemberId = registerVM.MemberId,
                BookId = registerVM.BookId,
                BorrowDate = DateTime.Now
            };
            _context.Set<Borrow>().Add(borrow);
            result += _context.SaveChanges();

            //insert to book table
            var book = new Book
            {
                BookTitle = registerVM.BookTitle,
                Author = registerVM.Author,
                Type = registerVM.Type,
                Publisher = registerVM.Publisher,
                PublicationYear = registerVM.PublicationYear,
            };
            _context.Set<Borrow>().Add(borrow);
            result += _context.SaveChanges();

            //insert to member table
            var member = new Member
            {
                Id = registerVM.Id,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                PhoneNumber = registerVM.PhoneNumber,
                Address = registerVM.Address,
                Email = registerVM.Email
            };
            _context.Set<Member>().Add(member);
            result += _context.SaveChanges();

            //insert to AccountRole table
            var accountRoles = new AccountRoles
            {
                AccountId = registerVM.Id,
                role_id = 2 // member
            };
            _context.Set<AccountRoles>().Add(accountRoles);
            result += _context.SaveChanges();

            return result;
        }
        public bool Login(LoginVM loginVM)
        {
            //Ambil data dari database berdasarkan Email di tabel employee
            //Gabungkan data dari tabel employee dengan tabel account berdasarkan NIK
            //Cocokan data tersebut dengan Password yang diinputkan
            //Cek apakah data valid atau tidak
            var getMemberAccount = _context.Member.Join(_context.Accounts,
                                                     m => m.Id,
                                                     a => a.memberId,
                                                     (m, a) => new
                                                     {
                                                         Email = m.Email,
                                                         Password = a.password
                                                     }).FirstOrDefault(e => e.Email == loginVM.Email);

            if (getMemberAccount == null)
            {
                return false;
            }

            return Hashing.ValidatePassword(loginVM.Password, getMemberAccount.Password);
        }
        public int Register(RegisterAccountVM registerAccountVM)
        {
            int result = 0;
            //insert to Account table
            var accounts = new Accounts
            {
                memberId = registerAccountVM.Id,
                password = Hashing.HashPassword(registerAccountVM.Password)
            };
            _context.Set<Accounts>().Add(accounts);
            result += _context.SaveChanges();

            return result;
        }
    }
}