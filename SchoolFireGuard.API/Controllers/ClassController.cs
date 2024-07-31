using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolFireGuard.API.DAL;
using SchoolFireGuard.API.DTOS.classDTOs;

namespace SchoolFireGuard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassDAL _classDal;

        public ClassController(IConfiguration configuration)
        {


            string connectionString = configuration.GetConnectionString("cs");
            _classDal = new ClassDAL(connectionString);
         
        }

        [HttpGet]
        public ActionResult<List<GetClassDTO>> GetAllClasses()
        {
            var classes = _classDal.GetAllClasses();
            if (classes == null || classes.Count == 0)
            {
                return NotFound("No classes found.");
            }

            return Ok(classes);
        }
        [HttpGet("names")]
        public ActionResult<List<GetClassNameDTO>> GetClassNames()
        {
            var classNames = _classDal.GetAllClassNames();
            if (classNames == null || classNames.Count == 0)
            {
                return NotFound("No class names found.");
            }

            return Ok(classNames);
        }
    }
}
