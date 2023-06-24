using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using API.Model;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using API.Base;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficerController : GeneralController<IOfficerRepository, Officer, int>
    {
        public OfficerController(IOfficerRepository repository) : base(repository)
        {
        }
    }
}
