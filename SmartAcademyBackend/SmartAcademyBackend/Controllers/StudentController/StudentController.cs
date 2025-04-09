using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Service.StudentService;

namespace SmartAcademyBackend.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> addNewStudent(AddStudentDTO addStudent)
        {
            var student = await studentService.addNewStudent(addStudent);
            if (student is null)
                return BadRequest();
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetStudentInfoDTO>>> getAllStudentsInformation()
        {
            return Ok(await studentService.getAllStudentInformation());
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<GetStudentInfoDTO>> geStudentsInformationById(int studentId)
        {
           var student= await studentService.getStudentInformationById(studentId);

            if(student is null)
                return NotFound();
            return Ok(student);
        }

    }

}
