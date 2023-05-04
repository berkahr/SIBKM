using API.Base;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingsController : GeneralController<IProfilingsRepository, Profilings, string>
    {
        public ProfilingsController(IProfilingsRepository repository) : base(repository) { }
    }
}
