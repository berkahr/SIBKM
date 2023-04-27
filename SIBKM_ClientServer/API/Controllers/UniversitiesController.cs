using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversitiesRepository _universitiesRepository;
        public UniversitiesController(IUniversitiesRepository universitiesRepository)
        {
            _universitiesRepository = universitiesRepository;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var universities = _universitiesRepository.GetAll();

            return Ok(new ResponseDataVM<IEnumerable<Universities>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "succes",
                Data = universities
            });
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var universities = _universitiesRepository.GetById(id);
            if (universities == null)
                return NotFound(new ResponseErrorsVM<string>{
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id not found"
            });

            return Ok(new ResponseDataVM<Universities>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "succes",
                Data = universities
            });
        }

        [HttpPost]
        public ActionResult Insert(Universities universities)
        {
            if (universities.name == ""|| universities.name.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value cannot be Null or Default"
                });
            }
            var insert = _universitiesRepository.Insert(universities);
            if (insert > 0)
                return Ok(new ResponseDataVM<Universities>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success",
                    Data = null!
                });

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }
        [HttpPut]
        public ActionResult Update(Universities universities)
        {
            if (universities.name == "" || universities.name.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value cannot be Null or Default"
                });
            }
            var update = _universitiesRepository.Update(universities);
            if (update > 0) return Ok(new ResponseDataVM<Universities>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Update Success",
                Data = null!
            });
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var delete = _universitiesRepository.Delete(id);
            if (delete > 0) return Ok(new ResponseDataVM<Universities>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete Success",
                Data = null!
            });
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }
    }
}
