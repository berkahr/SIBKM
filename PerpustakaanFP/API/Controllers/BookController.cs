using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using API.Model;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using API.Base;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BookController : GeneralController<IBookRepository, Book, int>
    {
        public BookController(IBookRepository repository) : base(repository)
        {
        }
    }
}
