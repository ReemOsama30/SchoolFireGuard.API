using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolFireGuard.API.DAL;
using SchoolFireGuard.API.DTOS.classDTOs;
using SchoolFireGuard.API.responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolFireGuard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassDAL _classDal;

        public ClassController(ClassDAL classDal)
        {
            _classDal = classDal;
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

        [HttpGet("totalclasses")]
        public async Task<ActionResult<GeneralResponse>> GetTotalClasses()
        {
            var totalClasses = _classDal.GetTotalClasses();
            if (totalClasses >= 0)
            {
                return Ok(totalClasses);
            }
            else
            {
                return new GeneralResponse { message = "invalid classes", status = 500 };
            }
        }

        [HttpGet("totalstudents")]
        public async Task<ActionResult<GeneralResponse>> GetTotalStudents()
        {
            var totalStudents = _classDal.GetTotalStudents();
            if (totalStudents >= 0)
            {
                return Ok(totalStudents);
            }
            else
            {
                return new GeneralResponse { status = 500, message = "Internal server error" };
            }
        }
    }
}
