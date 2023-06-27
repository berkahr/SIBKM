﻿using API.Base;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using API.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AccountsController : GeneralController<IAccountsRepository, Accounts, string>
    {
        private readonly ITokenService _tokenService;
        private readonly IMemberRepository _memberRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountsController(
            IAccountsRepository repository,
            ITokenService tokenService,
            IMemberRepository memberRepository,
            IAccountRoleRepository accountRoleRepository) : base(repository)
        {
            _tokenService = tokenService;
            _memberRepository = memberRepository;
            _accountRoleRepository = accountRoleRepository;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = _repository.Login(loginVM);
            if (!login)
            {
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Login Failed, Account or Password Not Found!"
                });
            }

            var claims = new List<Claim>() {
            new Claim("Email", loginVM.Email),
            new Claim("FullName", _memberRepository.GetFullNameByEmail(loginVM.Email))
            };

            var getRoles = _accountRoleRepository.GetRolesByEmail(loginVM.Email);
            foreach (var role in getRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = _tokenService.GenerateToken(claims);

            return Ok(new ResponseDataVM<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login Success",
                Data = token
            });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public ActionResult Register(RegisterAccountVM registerAccountVM)
        {
            var register = _repository.Register(registerAccountVM);
            if (register > 0)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success"
                });
            }

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }
    }
}