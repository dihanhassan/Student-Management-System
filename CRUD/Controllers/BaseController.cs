using CRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Dto.Student;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public BaseController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Route("Get-All-Students")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await _studentService.GetAllStudents();
            if (response.Status == 100)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
        [Route("Registration-Student")]
        [HttpPost]
        public async Task<IActionResult> RegistrationStudent([FromBody] StudentInfo student)
        {
            var response = await _studentService.RegistrationStudent(student);
            if (response.Status == 100)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
       
        [Route("Update-Student")]
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentInfo student)
        {
            var response = await _studentService.UpdateStudent(student);
            if (response.Status == 100)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
        [Route("Delete-Student")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent([FromBody] string id)
        {
            var response = await _studentService.DeleteStudent(id);
            if (response.Status == 100)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
