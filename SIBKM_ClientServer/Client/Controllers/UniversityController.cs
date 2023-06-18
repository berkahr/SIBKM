using API.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
public class UniversityController : Controller
{
    private readonly UniversitityRepository repository;

    public UniversityController(UniversitityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        //localhost/university/
        var Results = await repository.Get();
        var universities = new List<Universities>();

        if (Results != null)
        {
            universities = Results.Data.ToList();
        }

        return View(universities);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Universities universities)
    {

        var result = await repository.Post(universities);
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

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        //localhost/university/
        var Results = await repository.Get(id);
        //var universities = new University();

        //if (Results != null)
        //{
        //    universities = Results.Data;
        //}

        return View(Results.Data);
    }
}