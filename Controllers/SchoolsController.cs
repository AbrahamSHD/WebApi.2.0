using Microsoft.AspNetCore.Mvc;
using SchoolsWebApi.Models;
using SchoolsWebApi.Services;

namespace SchoolsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolService _service;

        public SchoolsController(SchoolService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<School>> GetAllSchools()
        {
            var schools = _service.GetSchools();
            return Ok(schools);
        }

        [HttpGet("{name}")]
        public ActionResult<School> GetSchoolByName(string name)
        {
            var school = _service.GetSchoolByName(name);
            if (school == null) return NotFound();
            return Ok(school);
        }
    }
}
