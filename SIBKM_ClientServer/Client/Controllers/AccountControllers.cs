using API.Models;
using API.ViewModels;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Reflection;

namespace Client.Controllers;
public class AccountController : Controller
{
    private readonly AccountsRepository repository;

    public AccountController(AccountsRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login)
    {
        var result = await repository.Login(login);
        if (result.Code == 200)
        {
            HttpContext.Session.SetString("JWToken", result.Data);
            return RedirectToAction("index", "home");
        }
        return View();
    }

    [HttpGet("/Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/Account/Login");
    }

    public async Task<IActionResult> Index()
    {
        //localhost/Account
        var Results = await repository.Get();
        var accounts = new List<Accounts>();

        if (Results != null)
        {
            accounts = Results.Data.ToList();
        }

        return View(accounts);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Accounts account)
    {
        var result = await repository.Post(account);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil masuk";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Code == 409)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }

        return View();
    }
}