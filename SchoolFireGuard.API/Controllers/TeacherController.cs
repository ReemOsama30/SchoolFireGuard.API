using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolFireGuard.API.DAL;
using SchoolFireGuard.API.DTOS.teacherDTOs;
using SchoolFireGuard.API.responses;
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
        public async Task<ActionResult<GeneralResponse>> InsertTeacher([FromBody] addTeacherDTO teacher)
        {
            if (teacher == null)
            {
                return new GeneralResponse
                {
                    message = "error in inserting teacher data..."
                    ,
                    status = 400
                };
            }

            _teacherDAL.InsertTeacher(teacher);
            return new GeneralResponse
            {
                message = "teacher inseted successfully",
                status = 200
            };
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
