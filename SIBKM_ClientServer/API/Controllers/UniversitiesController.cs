using API.Base;
using API.Models;
using API.Repositories;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : GeneralController<IUniversitiesRepository, Universities, int>
{
    public UniversitiesController(IUniversitiesRepository repository) : base(repository) { }
}


