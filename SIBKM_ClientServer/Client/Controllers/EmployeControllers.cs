using API.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class EmployeController : Controller
    {
        private readonly EmployeRepository repository;

        public EmployeController(EmployeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var Results = await repository.Get();
            var employees = new List<Employee>();

            if (Results != null)
            {
                employees = Results.Data.ToList();
            }

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            var result = await repository.Post(employee);
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
        public async Task<IActionResult> Details(string nik)
        {
            var Results = await repository.Get(nik);
            var employee = Results.Data;
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string nik)
        {
            var Results = await repository.Get(nik);
            var employee = new Employee();

            if (Results.Data?.nik is null)
            {
                return View(employee);
            }
            else
            {
                employee.nik = Results.Data.nik ;
                employee.first_name = Results.Data.first_name;
                employee.last_name = Results.Data.last_name;
                employee.birthdate = Results.Data.birthdate;
                employee.gender = Results.Data.gender;
                employee.hiring_date = Results.Data.hiring_date;
                employee.email = Results.Data.email;
                employee.phone_number = Results.Data.phone_number;
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Put(employee.nik, employee);
                if (result.Code == 200)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (result.Code == 409)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string nik)
        {
            var result = await repository.Get(nik);
            var employee = result?.Data;

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(string nik)
        {
            var result = await repository.Delete(nik);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }

            var employee = await repository.Get(nik);
            return View("Delete", employee?.Data);
        }
    }
}