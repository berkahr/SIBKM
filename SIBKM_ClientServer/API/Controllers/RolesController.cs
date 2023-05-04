using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : GeneralController<IRolesRepository, Roles, int>
    {
        public RolesController(IRolesRepository repository) : base(repository) { }
    }
}
