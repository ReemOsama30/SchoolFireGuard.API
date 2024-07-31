using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolFireGuard.API.DAL;
using SchoolFireGuard.API.DTOS.teacherDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolFireGuard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherDAL _teacherDAL;

        public TeacherController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("cs");
            _teacherDAL = new TeacherDAL(connectionString);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTeacher([FromBody] addTeacherDTO teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher is null.");
            }

            _teacherDAL.InsertTeacher(teacher);
            return Ok("Teacher inserted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTeachersDTO>>> GetAllTeachers()
        {
            return Ok(_teacherDAL.GetAllTeachers());
        }

        [HttpDelete]
        [Route("remove-all")]
        public IActionResult RemoveAllTeachers()
        {
            _teacherDAL.RemoveAllTeachers();
            return Ok("All teachers removed successfully.");
        }
    }
}
